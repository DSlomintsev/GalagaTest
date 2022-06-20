using UnityEngine;

namespace Galaga.MainMenu.Commands
{
    public struct QuitGameSignal
    {
    }

    public class QuitGameCommand
    {
        public void Execute(QuitGameSignal signal)
        {
            Application.Quit();
        }
    }
}