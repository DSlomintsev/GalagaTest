namespace Galaga.Game.Commands
{
    public class SpawnUnitSignal
    {
    }

    public class SpawnUnitCommand
    {
        /*[Inject]
        public void Construct(GameModel gameModel, PlayersModel playersModel)
        {
            _player = playersModel.CurrentPlayer;
        }*/

        public void Execute(SpawnUnitSignal signal)
        {
        }
    }
}