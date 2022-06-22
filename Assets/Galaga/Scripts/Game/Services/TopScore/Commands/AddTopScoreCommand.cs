using Galaga.MainMenu.Services.TopScore;
using Zenject;

namespace Galaga.MainMenu.Commands
{
    public struct AddTopScoreSignal
    {
        public string Name { get; }
        public float Score { get; }

        public AddTopScoreSignal(string name, float score)
        {
            Name = name;
            Score = score;
        }
    }

    public class AddTopScoreCommand
    {
        [Inject] public ITopScoreService TopScoreService { get; set; }

        public void Execute(AddTopScoreSignal signal)
        {
            TopScoreService.AddScoreItem(signal.Name,signal.Score);
        }
    }
}