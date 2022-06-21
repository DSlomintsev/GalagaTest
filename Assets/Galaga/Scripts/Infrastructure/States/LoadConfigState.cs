using Galaga.Infrastructure.Config;
using Galaga.Infrastructure.Loading;
using Zenject;


namespace Galaga.Infrastructure.States
{
    public class LoadConfigState : IState
    {
        [Inject] public AppStateMachine AppStateMachine { get; set; }
        [Inject] public SceneLoader SceneLoader { get; set; }
        [Inject] public ConfigProviderService ConfigProviderService { get; set; }

        public void Enter()
        {
            //_configProviderService.Load(HandleLoadConfigs);
            SceneLoader.Load(SceneNames.MainMenu, onLoaded: HandleSceneLoaded);
        }

        public void Exit()
        {
        }

        private void HandleSceneLoaded()
        {
            AppStateMachine.Enter<MainMenuState>();
        }
    }
}
