using Cysharp.Threading.Tasks;
using Galaga.Common.Services.Dialog;
using Galaga.MainMenu.Services.Waves;
using Galaga.MainMenu.UI.Dialogs.MainMenu;
using Zenject;


namespace Galaga.MainMenu.Commands
{
    public struct LevelLoseSignal
    {
    }

    public class LevelLoseCommand
    {
        [Inject] public DialogService DialogService { get; set; }
        [Inject] public LevelService LevelService { get; set; }
        [Inject] public SignalBus SignalBus { get; set; }

        public void Execute(LevelLoseSignal signal)
        {
            DialogService.OpenDialog<SaveScoreDialogViewModel>();
            WaitDialogClose();
        }

        private async UniTask WaitDialogClose()
        {
            await UniTask.WaitUntil(() => !DialogService.IsDialogOpened<SaveScoreDialogViewModel>());
            SignalBus.Fire<GoToMainMenuSignal>();
        }
    }
}