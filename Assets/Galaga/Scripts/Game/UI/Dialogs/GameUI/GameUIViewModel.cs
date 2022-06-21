using System;
using Galaga.Common.Services.Dialog;
using Galaga.Common.Utils.Data;
using Galaga.Game.Model;
using Galaga.MainMenu.Commands;
using Zenject;

namespace Galaga.MainMenu.UI.Dialogs.MainMenu
{
    public class GameUIViewModel:BaseDialogViewModel, IInitializable, IDisposable
    {
        [Inject] public SignalBus SignalBus { get; set; }
        [Inject] public GameModel GameModel { get; set; }
        public ActiveData<float> Score => GameModel.Score;

        public void Initialize()
        {
        }
        
        public void Dispose()
        {
        }
        
        public void OnContinueGame()
        {
            SignalBus.Fire<ContinueGameSignal>();
        }

        public void OnQuitGame()
        {
            SignalBus.Fire<QuitGameSignal>();
        }
    }    
}