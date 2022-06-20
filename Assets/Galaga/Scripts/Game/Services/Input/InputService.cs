using System;
using Galaga.Game.Model;
using Galaga.Game.Services.Input.Handlers;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;


namespace Galaga.Game.Services.Input
{
    public class InputService : MonoBehaviour, IInitializable, IDisposable
    {
        [Inject] public GameModel GameModel { get; set; }
        [Inject] public DiContainer DiContainer { get; set; }
        
        private PlayerInput _input;

        public PlayerInputHandler PlayerInputHandler = new();
        public UIInputHandler UIInputHandler = new();

        private IInputHandler _currentInput;

        private InputActionType _actionMap;

        public void Initialize()
        {
            _input = gameObject.GetComponent<PlayerInput>();

            _input.SwitchCurrentActionMap(InputActionType.PLAYER.ToString());
            DiContainer.Inject(PlayerInputHandler);
            PlayerInputHandler.Init(_input);
            
            _input.SwitchCurrentActionMap(InputActionType.UI.ToString());
            DiContainer.Inject(UIInputHandler);
            UIInputHandler.Init(_input);
            
            GameModel.IsUI.UpdateEvent += OnIsUIUpdate;
            OnIsUIUpdate(GameModel.IsUI.Value);
        }

        private void OnIsUIUpdate(bool isUI)
        {
            var state = isUI ? GameState.UI : GameState.PLAYER;
            var actionMap = state switch
            {
                GameState.PLAYER => InputActionType.PLAYER,
                GameState.UI => InputActionType.UI,
            };
            
            if (_actionMap != actionMap)
            {
                _actionMap = actionMap;

                _currentInput?.Stop();
                
                _input.SwitchCurrentActionMap(_actionMap.ToStr());

                _currentInput = _actionMap switch
                {
                    InputActionType.PLAYER => PlayerInputHandler,
                    InputActionType.UI => UIInputHandler,
                    _ => throw new ArgumentOutOfRangeException()
                };

                _currentInput.Start();
            }
        }

        public void Dispose()
        {
        }
    }
}