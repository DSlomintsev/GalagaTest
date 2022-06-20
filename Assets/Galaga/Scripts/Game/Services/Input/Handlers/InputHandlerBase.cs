using UnityEngine.InputSystem;

namespace Galaga.Game.Services.Input.Handlers
{
    public class InputHandlerBase:IInputHandler
    {
        private bool _isStart; 
        protected PlayerInput Input;
        
        public void Init(PlayerInput playerInput)
        {
            Input = playerInput;
        }
        
        public void DeInit()
        {
            Input = null;
        }

        public void Start()
        {
            if (!_isStart)
            {
                _isStart = true;
                OnStart();
            }
        }

        public void Stop()
        {
            if (!_isStart)
            {
                _isStart = true;
                OnStop();
            }
        }
        
        protected virtual void OnStart()
        {
            
        }
        
        protected virtual void OnStop()
        {
            
        }
    }
}