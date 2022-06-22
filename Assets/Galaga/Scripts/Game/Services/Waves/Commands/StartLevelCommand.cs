using Galaga.MainMenu.Services.TopScore;
using Galaga.MainMenu.Services.Waves;
using Zenject;

namespace Galaga.MainMenu.Commands
{
    public struct StartLevelSignal
    {
        public string LevelId { get; }

        public StartLevelSignal(string levelId)
        {
            LevelId = levelId;
        }
    }

    public class StartLevelCommand
    {
        [Inject] public LevelService LevelService { get; set; }

        public void Execute(StartLevelSignal signal)
        {
            LevelService.PlayLevel();
        }
    }
}