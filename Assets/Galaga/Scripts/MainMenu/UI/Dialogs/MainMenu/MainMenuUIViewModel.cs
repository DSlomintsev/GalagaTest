using System;
using Galaga.Common.Services.Dialog;
using Galaga.MainMenu.Commands;
using Zenject;

namespace Galaga.MainMenu.UI.Dialogs.MainMenu
{
    public class MainMenuUIViewModel:BaseDialogViewModel, IInitializable, IDisposable
    {
        [Inject] public SignalBus SignalBus;

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
            SignalBus.Fire<OpenTopScoreSignal>();
        }
        
        public void OnQuitGame()
        {
            SignalBus.Fire<QuitGameSignal>();
        }
    }    
}