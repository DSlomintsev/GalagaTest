using Galaga.MainMenu.Services.Waves;
using Zenject;


namespace Galaga.MainMenu.Commands
{
    public struct StopLevelSignal
    {
    }

    public class StopLevelCommand
    {
        [Inject] public LevelService LevelService { get; set; }

        public void Execute(StopLevelSignal signal)
        {
            LevelService.StopLevel();
        }
    }
}