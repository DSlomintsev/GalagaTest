using System;
using Galaga.Common.Services.Dialog;
using Galaga.Common.Utils.Data;
using Galaga.MainMenu.Services.TopScore;
using Zenject;


namespace Galaga.MainMenu.UI.Dialogs.TopScore
{
    public class TopScoreDialogViewModel:BaseDialogViewModel,IInitializable,IDisposable
    {
        [Inject] public SignalBus SignalBus { get; set; }
        [Inject] public ITopScoreService TopScoreService { get; set; }
        [Inject] public DialogService DialogService { get; set; }
        public ActiveListData<TopScoreItemData> Score => TopScoreService.Score;
        
        public void Initialize()
        {
        }

        public void Dispose()
        {
        }

        public void Close()
        {
            DialogService.CloseDialog<TopScoreDialogViewModel>();
        }

        
    }
}
