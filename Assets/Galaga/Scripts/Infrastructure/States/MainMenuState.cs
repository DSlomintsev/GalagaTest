
using Galaga.Common.Services.Dialog;
using Galaga.Game.Model;
using Galaga.Infrastructure.Loading;
using Galaga.MainMenu.UI.Dialogs.MainMenu;
using Zenject;

namespace Galaga.Infrastructure.States
{
    public class MainMenuState : IState
    {
        [Inject] public LoadingSceneAnim LoadingSceneAnim { get; set; }
        [Inject] public DialogService DialogService { get; set; }
        [Inject] public GameModel GameModel { get; set; }
        
        public void Enter()
        {
            GameModel.IsUI.Value = true;
            LoadingSceneAnim.Hide();
            DialogService.OpenDialog<MainMenuUIViewModel>();
        }

        public void Exit()
        {
            DialogService.CloseDialog<MainMenuUIViewModel>();
        }
    }
}