using Cysharp.Threading.Tasks;
using Galaga.Common.Services.Dialog;
using Galaga.MainMenu.Services.Waves;
using Galaga.MainMenu.UI.Dialogs.MainMenu;
using Zenject;


namespace Galaga.MainMenu.Commands
{
    public struct LevelFinishedSignal
    {
    }

    public class LevelFinishedCommand
    {
        [Inject] public DialogService DialogService { get; set; }
        [Inject] public LevelService LevelService { get; set; }

        public void Execute(LevelFinishedSignal signal)
        {
            DialogService.OpenDialog<SaveScoreDialogViewModel>();
            WaitDialogClose();
        }

        private async UniTask WaitDialogClose()
        {
            await UniTask.WaitUntil(() => !DialogService.IsDialogOpened<SaveScoreDialogViewModel>());
            LevelService.LevelFinished();
        }
    }
}