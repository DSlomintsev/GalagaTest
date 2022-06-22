using Galaga.MainMenu.Services.TopScore;
using Zenject;

namespace Galaga.MainMenu.Commands
{
    public struct RemoveTopScoreSignal
    {
        public string Name { get; }

        public RemoveTopScoreSignal(string name)
        {
            Name = name;
        }
    }

    public class RemoveTopScoreCommand
    {
        [Inject] public TopScoreService TopScoreService { get; set; }

        public void Execute(RemoveTopScoreSignal signal)
        {
            TopScoreService.RemoveScoreItem(signal.Name);
        }
    }
}