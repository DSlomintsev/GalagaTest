using UnityEngine.InputSystem;

namespace Galaga.Game.Services.Input.Handlers
{
    public interface IInputHandler
    {
        public void Init(PlayerInput playerInput);

        public void DeInit();

        public void Start();

        public void Stop();
    }
}