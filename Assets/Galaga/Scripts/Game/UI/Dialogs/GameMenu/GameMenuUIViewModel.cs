using System;
using Galaga.Common.Services.Dialog;
using Galaga.MainMenu.Commands;
using Zenject;

namespace Galaga.MainMenu.UI.Dialogs.MainMenu
{
    public class GameMenuUIViewModel:BaseDialogViewModel, IInitializable, IDisposable
    {
        [Inject] public DialogService DialogService { get; set; }
        [Inject] public SignalBus SignalBus { get; set; }

        public void Initialize()
        {
        }
        
        public void Dispose()
        {
        }

        public void OnScore()
        {
            DialogService.OpenDialog<SaveScoreDialogViewModel>();
        }

        public void OnContinueGame()
        {
            DialogService.CloseDialog<GameMenuUIViewModel>();
        }

        public void OnQuitGame()
        {
            DialogService.CloseDialog<GameMenuUIViewModel>();
            SignalBus.Fire<GoToMainMenuSignal>();
        }
    }    
}