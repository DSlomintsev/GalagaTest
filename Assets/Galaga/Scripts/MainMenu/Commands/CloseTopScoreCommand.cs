using Galaga.Common.Services.Dialog;
using Galaga.MainMenu.UI.Dialogs.TopScore;
using Zenject;

namespace Galaga.MainMenu.Commands
{
    public struct CloseTopScoreSignal
    {
    }

    public class CloseTopScoreCommand
    {
        [Inject] public DialogService DialogService { get; set; }

        public void Execute(CloseTopScoreSignal signal)
        {
            DialogService.CloseDialog<TopScoreDialogViewModel>();
        }
    }
}