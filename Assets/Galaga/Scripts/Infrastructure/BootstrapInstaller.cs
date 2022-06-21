using Galaga.Common.Services.Dialog;
using Galaga.Common.Services.SoundPlayer;
using Galaga.Common.UI;
using Galaga.Game.Model;
using Galaga.Game.Services.Input;
using Galaga.Infrastructure.Config;
using Galaga.Infrastructure.Factory;
using Galaga.Infrastructure.Loading;
using Galaga.Infrastructure.Services.AssetsManagement;
using Galaga.Infrastructure.Services.CoroutineRunner;
using Galaga.Infrastructure.Services.PersistentProgress;
using Galaga.Infrastructure.States;
using Galaga.MainMenu.Commands;
using Galaga.MainMenu.Services.TopScore;
using UnityEngine;
using Zenject;


namespace Galaga.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private LoadingSceneAnim loadingSceneAnimPrefab = default;
        [SerializeField] private UIContainer uiContainerPrefab = default;
        [SerializeField] private InputService inputServicePrefab = default;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
            
            Container.Bind<IAppFactory>().To<AppFactory>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<LoadingSceneAnim>().FromComponentInNewPrefab(loadingSceneAnimPrefab).AsSingle();
            Container.BindInterfacesAndSelfTo<UIContainer>().FromComponentInNewPrefab(uiContainerPrefab).AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().FromComponentInNewPrefab(inputServicePrefab).AsSingle();

            InstallUtils();
            InstallServices();
            InstallModels();
            InstallSignals();
            InstallCommands();
            
            InstallStateMachine();
        }

        private void InstallUtils()
        {
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
        }

        private void InstallSignals()
        {
            Container.DeclareSignal<AddTopScoreSignal>();
            Container.DeclareSignal<RemoveTopScoreSignal>();
            Container.DeclareSignal<PlayGameSignal>();
            Container.DeclareSignal<QuitGameSignal>();
            Container.DeclareSignal<ContinueGameSignal>();
            Container.DeclareSignal<PauseGameSignal>();
            
            Container.DeclareSignal<GoToMainMenuSignal>();
        }
        
        private void InstallCommands()
        {
            Container.BindSignal<AddTopScoreSignal>().ToMethod<AddTopScoreCommand>(handler => handler.Execute).FromNew();
            Container.BindSignal<RemoveTopScoreSignal>().ToMethod<RemoveTopScoreCommand>(handler => handler.Execute).FromNew();
            Container.BindSignal<PlayGameSignal>().ToMethod<PlayGameCommand>(handler => handler.Execute).FromNew();
            Container.BindSignal<QuitGameSignal>().ToMethod<QuitGameCommand>(handler => handler.Execute).FromNew();
            Container.BindSignal<ContinueGameSignal>().ToMethod<ContinueGameCommand>(handler => handler.Execute).FromNew();
            Container.BindSignal<PauseGameSignal>().ToMethod<PauseGameCommand>(handler => handler.Execute).FromNew();
            
            Container.BindSignal<GoToMainMenuSignal>().ToMethod<GoToMainMenuCommand>(handler => handler.Execute).FromNew();
        }

        private void InstallServices()
        {
            Container.Bind<ConfigProviderService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SoundPlayerService>().AsSingle();
            Container.BindInterfacesAndSelfTo<DialogService>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<TopScoreService>().AsSingle();
        }

        private void InstallModels()
        {
            Container.Bind<GameModel>().AsSingle();
        }

        private void InstallStateMachine()
        {
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LoadConfigState>().AsSingle();
            Container.Bind<MainMenuState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<AppLoopState>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<AppStateMachine>().AsSingle();
        }
    }
}