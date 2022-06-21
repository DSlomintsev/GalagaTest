using System;
using Galaga.Common.Utils;
using Galaga.Game.Model;
using UnityEngine.InputSystem;
using Zenject;

namespace Galaga.Game.Services.Input.Handlers
{
    public class UIInputHandler : InputHandlerBase
    {
        [Inject] public GameModel GameModel { get; set; }
        public event Action Escape;

        protected override void OnStart()
        {
            Input.actions["Escape"].performed += OnEscape;
        }

        protected override void OnStop()
        {
            Input.actions["Escape"].performed -= OnEscape;
        }

        private void OnEscape(InputAction.CallbackContext obj)
        {
            Escape.Call();
        }
    }
}