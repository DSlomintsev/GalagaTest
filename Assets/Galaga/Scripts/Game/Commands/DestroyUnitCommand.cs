namespace Galaga.Game.Commands
{
    public class DestroyUnitSignal
    {
    }

    public class DestroyUnitCommand
    {
        /*[Inject]
        public void Construct(GameModel gameModel, PlayersModel playersModel)
        {
            _player = playersModel.CurrentPlayer;
        }*/

        public void Execute(DestroyUnitSignal signal)
        {
        }
    }
}