using System;
using Galaga.Common.Services.Dialog;
using Galaga.MainMenu.Commands;
using Galaga.MainMenu.Services.TopScore;
using Zenject;


namespace Galaga.MainMenu.UI.Dialogs.TopScore
{
    public class TopScoreDialogViewModel:BaseDialogViewModel,IInitializable,IDisposable
    {
        [Inject] public SignalBus SignalBus { get; set; }
        [Inject] public ITopScoreService TopScoreService { get; set; }
        
        public void Initialize()
        {
        }

        public void Dispose()
        {
        }

        public void Close()
        {
            SignalBus.Fire<CloseTopScoreSignal>();
        }

        
    }
}
