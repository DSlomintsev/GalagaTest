using UnityEngine;


namespace Galaga.MainMenu.Commands
{
    public struct PauseGameSignal
    {
    }

    public class PauseGameCommand
    {
        public void Execute(PauseGameSignal signal)
        {
            Time.timeScale = 0f;

        }
    }
}