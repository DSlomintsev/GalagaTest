using Galaga.Game.Actors.Units.Parts;
using Galaga.Game.Actors.Weapons;
using Galaga.Game.Services.Input.Handlers;


namespace Galaga.Game.Actors.Units.AttackBehaviors
{
    public class AttackByPlayerInput:IAttack
    {
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
        void IAttack.DeInit()
        {
            throw new System.NotImplementedException();
        }

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
        }

        void IUnitComponent.DeInit()
        {
            PlayerInputHandler = null;
            _weapon.IsFirePressed.Value = false;
        }
    }
}