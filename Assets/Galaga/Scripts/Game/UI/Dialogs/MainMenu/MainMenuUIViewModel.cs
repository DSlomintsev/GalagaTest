using System;
using Galaga.Common.Services.Dialog;
using Galaga.MainMenu.Commands;
using Galaga.MainMenu.UI.Dialogs.TopScore;
using Zenject;

namespace Galaga.MainMenu.UI.Dialogs.MainMenu
{
    public class MainMenuUIViewModel:BaseDialogViewModel, IInitializable, IDisposable
    {
        [Inject] public SignalBus SignalBus { get; set; }
        [Inject] public DialogService DialogService { get; set; }

        public void Initialize()
        {
        }
        
        public void Dispose()
        {
        }
        
        public void OnPlayGame()
        {
            SignalBus.Fire<PlayGameSignal>();
        }
        
        public void OnOpenTopScore()
        {
            DialogService.OpenDialog<TopScoreDialogViewModel>();
        }
        
        public void OnQuitGame()
        {
            SignalBus.Fire<QuitGameSignal>();
        }
    }    
}