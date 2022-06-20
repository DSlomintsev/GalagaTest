using Galaga.Infrastructure.Loading;
using Zenject;


namespace Galaga.Infrastructure.States
{
    public class BootstrapState : IState
    {
        [Inject] public AppStateMachine AppStateMachine { get; set; }
        [Inject] public SceneLoader SceneLoader { get; set; }
        [Inject] public LoadingSceneAnim LoadingSceneAnim { get; set; }

        private const string BootSceneName = "Boot";

        public void Enter()
        {
            LoadingSceneAnim.Show();
            SceneLoader.Load(BootSceneName, onLoaded: HandleSceneLoaded);
        }

        public void Exit()
        {
        }

        private void HandleSceneLoaded() =>
            AppStateMachine.Enter<LoadConfigState>();
    }
}