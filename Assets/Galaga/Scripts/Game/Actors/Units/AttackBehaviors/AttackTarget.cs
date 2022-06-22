using Galaga.Game.Actors.Weapons;
using Game.Services;
using UnityEngine;
using Zenject;


namespace Galaga.Game.Actors.Units.AttackBehaviors
{
    public class AttackTarget:IAttack
    {
        [Inject] public TickService TickService { get; set; }

        private Transform _target;
        public Transform Target
        {
            set => _target = value;
        }

        private Weapon _weapon;
        public Weapon Weapon
        {
            set => _weapon = value;
        }

        public void Init()
        {
            TickService.AddTickAction(TickAction);
            _weapon.IsFirePressed.Value = true;
        }

        public void DeInit()
        {
            TickService.RemoveTickAction(TickAction);
            _weapon.IsFirePressed.Value = false;
        }

        private void TickAction()
        {
            var targetPos = _target == null ? Vector3.zero : _target.position;
            var target = new Vector2(targetPos.x,targetPos.y);
            var sourcePos=_weapon.PositionContainer.Pos;
            
            var dir = new Vector2(target.x, target.y) - sourcePos;
            
            var angle = Vector3.Angle(Vector3.right, dir);
            if(target.y < sourcePos.y) angle *= -1;

            _weapon.Rotation =  Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}