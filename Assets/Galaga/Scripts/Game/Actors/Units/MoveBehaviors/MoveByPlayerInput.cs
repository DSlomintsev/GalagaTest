using Galaga.Game.Actors.Units.Parts;
using Galaga.Game.Services.Input.Handlers;
using Game.Services;
using UnityEngine;
using Zenject;

namespace Galaga.Game.Actors.Units.MoveBehaviors
{
    public class MoveByPlayerInput:IMovable
    {
        [Inject] public TickService TickService { get; set; }

        public void Init()
        {
            TickService.AddFixedTickAction(FixedTick);
        }
        
        public void DeInit()
        {
            TickService.RemoveFixedTickAction(FixedTick);
        }
        
        private PlayerInputHandler _playerInputHandler;
        public PlayerInputHandler PlayerInputHandler
        {
            set
            {
                _playerInputHandler = value;
            }
        }

        private Rigidbody2D _rigidbody;
        public Rigidbody2D Rigidbody
        {
            set
            {
                _rigidbody = value;
            }
        }

        private float _speed=0;
        public float Speed { set => _speed = value; }

        private void FixedTick()
        {
            var movementInput = _playerInputHandler.MovementInput*_speed;
            var playerPos = _rigidbody.position;
            
            if (playerPos.x < -5f)
                movementInput.x = Mathf.Max(0, movementInput.x);
            
            if (playerPos.x > 5f)
                movementInput.x = Mathf.Min(0, movementInput.x);
            
            if (playerPos.y < -4.3f)
                movementInput.y = Mathf.Max(0, movementInput.y);
            
            if (playerPos.y > 4.3f)
                movementInput.y = Mathf.Min(0, movementInput.y);

            _rigidbody.velocity = movementInput;
        }
    }
}