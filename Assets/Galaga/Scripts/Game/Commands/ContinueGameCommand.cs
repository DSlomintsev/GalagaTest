using UnityEngine;

namespace Galaga.MainMenu.Commands
{
    public struct ContinueGameSignal
    {
    }

    public class ContinueGameCommand
    {
        public void Execute(ContinueGameSignal signal)
        {
            Time.timeScale = 1f;
        }
    }
}