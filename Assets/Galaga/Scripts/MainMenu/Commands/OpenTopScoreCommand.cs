using Galaga.Common.Services.Dialog;
using Galaga.MainMenu.UI.Dialogs.TopScore;
using Zenject;

namespace Galaga.MainMenu.Commands
{
    public struct OpenTopScoreSignal
    {
    }

    public class OpenTopScoreCommand
    {
        [Inject] public DialogService DialogService { get; set; }

        public void Execute(OpenTopScoreSignal signal)
        {
            DialogService.OpenDialog<TopScoreDialogView,TopScoreDialogViewModel>();
        }
    }
}