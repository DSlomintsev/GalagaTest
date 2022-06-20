
using Galaga.Common.Services.Dialog;
using Galaga.Infrastructure.Loading;
using Galaga.MainMenu.UI.Dialogs.MainMenu;
using Zenject;

namespace Galaga.Infrastructure.States
{
    public class MainMenuState : IState
    {
        [Inject] public LoadingSceneAnim LoadingSceneAnim { get; set; }
        [Inject] public DialogService DialogService { get; set; }
        
        public void Enter()
        {
            LoadingSceneAnim.Hide();
            DialogService.OpenDialog<MainMenuUIView,MainMenuUIViewModel>();
        }

        public void Exit()
        {
            DialogService.CloseDialog<MainMenuUIViewModel>();
        }
    }
}