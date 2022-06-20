namespace Galaga.Game.Commands
{
    public class ShotSignal
    {
    }

    public class ShotCommand
    {
        /*[Inject]
        public void Construct(GameModel gameModel, PlayersModel playersModel)
        {
            _player = playersModel.CurrentPlayer;
        }*/

        public void Execute(ShotSignal signal)
        {
        }
    }
}