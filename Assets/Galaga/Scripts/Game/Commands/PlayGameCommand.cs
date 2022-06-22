using Galaga.Infrastructure;
using Galaga.Infrastructure.Loading;
using Galaga.Infrastructure.States;
using Zenject;


namespace Galaga.MainMenu.Commands
{
    public struct PlayGameSignal
    {
    }

    public class PlayGameCommand
    {
        [Inject] public AppStateMachine AppStateMachine { get; set; }
        [Inject] public SceneLoader SceneLoader { get; set; }
        [Inject] public LoadingSceneAnim LoadingSceneAnim { get; set; }

        public void Execute(PlayGameSignal signal)
        {
            LoadingSceneAnim.Show();
            SceneLoader.Load(SceneNames.Level, onLoaded: HandleSceneLoaded);
        }

        private void HandleSceneLoaded()
        {
            LoadingSceneAnim.Hide();
            AppStateMachine.Enter<AppLoopState>();
        }
    }
}