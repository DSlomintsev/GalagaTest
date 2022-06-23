using System;
using Galaga.Common.Utils;
using Galaga.Common.Utils.Data;
using Galaga.Game.Model;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Galaga.Game.Services.Input.Handlers
{
    public class PlayerInputHandler : InputHandlerBase
    {
        [Inject] public GameModel GameModel { get; set; }
        public Vector2 MovementInput { get; private set; }
        public Vector2 LookInput { get; private set; }
        public Vector2 MobileLookInput { get; private set; }

        public ActiveData<bool> IsFire = new();
        public event Action Escape;

        protected override void OnStart()
        {
            Input.actions["Move"].performed += OnMoveUpdate;
            Input.actions["Move"].canceled += OnMoveStop;
            
            Input.actions["Look"].performed += OnLookUpdate;
            Input.actions["MobileLook"].performed += OnMobileLookUpdate;

            Input.actions["Fire"].performed += OnStartFire;
            Input.actions["Fire"].canceled += OnStopFire;
            
            Input.actions["Escape"].performed += OnEscape;
        }

        protected override void OnStop()
        {
            Input.actions["Move"].performed -= OnMoveUpdate;
            Input.actions["Move"].canceled -= OnMoveStop;
            
            Input.actions["Look"].performed += OnLookUpdate;
            Input.actions["MobileLook"].performed += OnMobileLookUpdate;

            Input.actions["Fire"].performed -= OnStartFire;
            Input.actions["Fire"].canceled -= OnStopFire;
            
            Input.actions["Escape"].performed -= OnEscape;

            MovementInput = Vector2.zero;
            IsFire.Value = false;
        }

        private void OnStartFire(InputAction.CallbackContext obj)
        {
            IsFire.Value = true;
        }
        
        private void OnStopFire(InputAction.CallbackContext obj)
        {
            IsFire.Value = false;
        }

        private void OnEscape(InputAction.CallbackContext obj)
        {
            Escape.Call();
        }

        private void OnMoveUpdate(InputAction.CallbackContext obj)
        {
            MovementInput = obj.ReadValue<Vector2>();
        }
        
        private void OnLookUpdate(InputAction.CallbackContext obj)
        {
            LookInput = obj.ReadValue<Vector2>();
        }
        
        private void OnMobileLookUpdate(InputAction.CallbackContext obj)
        {
            MobileLookInput = obj.ReadValue<Vector2>();
        }
        
        private void OnMoveStop(InputAction.CallbackContext obj)
        {
            MovementInput = Vector2.zero;
        }
    }
}