using Galaga.Infrastructure;
using Galaga.Infrastructure.Loading;
using Galaga.Infrastructure.States;
using Zenject;

namespace Galaga.MainMenu.Commands
{
    public struct GoToMainMenuSignal
    {
    }

    public class GoToMainMenuCommand
    {
        [Inject] public SignalBus SignalBus { get; set; }
        [Inject] public SceneLoader SceneLoader { get; set; }
        [Inject] public AppStateMachine AppStateMachine { get; set; }

        public void Execute(GoToMainMenuSignal signal)
        {
            
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