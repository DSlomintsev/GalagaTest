using System;
using Galaga.Common.Services.Dialog;
using Galaga.Common.Utils.Data;
using Galaga.Game.Model;
using Galaga.MainMenu.Commands;
using Zenject;

namespace Galaga.MainMenu.UI.Dialogs.MainMenu
{
    public class SaveScoreDialogViewModel:BaseDialogViewModel, IInitializable, IDisposable
    {
        [Inject] public GameModel GameModel { get; set; }
        [Inject] public SignalBus SignalBus { get; set; }
        [Inject] public DialogService DialogService { get; set; }
        
        public ActiveData<float> Score => GameModel.Score;

        public void Initialize()
        {
        }
        
        public void Dispose()
        {
        }
        
        public void OnContinueGame(string name)
        {
            SignalBus.Fire(new AddTopScoreSignal(name, Score.Value));
            DialogService.CloseDialog<SaveScoreDialogViewModel>();
        }
    }    
}