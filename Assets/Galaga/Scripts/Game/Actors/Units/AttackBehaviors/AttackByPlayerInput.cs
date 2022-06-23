using Galaga.Game.Actors.Weapons;
using Galaga.Game.Services.Input.Handlers;
using Game.Services;
using UnityEngine;
using Zenject;


namespace Galaga.Game.Actors.Units.AttackBehaviors
{
    public class AttackByPlayerInput:IAttack
    {
        [Inject] public TickService TickService { get; set; }
        private Camera _camera;
        public Camera Camera
        {
            set => _camera = value;
        }
        private PlayerInputHandler _playerInputHandler;
        public PlayerInputHandler PlayerInputHandler
        {
            set
            {
                if (_playerInputHandler != null)
                {
                    _playerInputHandler.IsFire.UpdateEvent -= OnIsFireUpdate;
                }

                _playerInputHandler = value;
                
                if (_playerInputHandler != null)
                {
                    _playerInputHandler.IsFire.UpdateEvent += OnIsFireUpdate;
                }
            }
        }

        private Weapon _weapon;
        

        public Weapon Weapon
        {
            set => _weapon = value;
        }

        private void OnIsFireUpdate(bool isFire)
        {
            _weapon.IsFirePressed.Value = isFire;
        }

        public void Init()
        {
            TickService.AddTickAction(TickAction);
        }
        
        public void DeInit()
        {
            PlayerInputHandler = null;
            _weapon.IsFirePressed.Value = false;
            TickService.RemoveTickAction(TickAction);
        }

        private void TickAction()
        {
            var angle = 0f;
            if (Application.isMobilePlatform)
            {
                angle = Mathf.Atan2(_playerInputHandler.MobileLookInput.y,_playerInputHandler.MobileLookInput.x);
                angle = angle*Mathf.Rad2Deg;
            }
            else
            {
                var target = _camera.ScreenToWorldPoint(_playerInputHandler.LookInput);
                var sourcePos=_weapon.PositionContainer.Pos;
            
                var dir = new Vector2(target.x, target.y) - sourcePos;
            
                angle = Vector3.Angle(Vector3.right, dir);
                if(target.y < sourcePos.y) angle *= -1;
            }
            
            _weapon.Rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}