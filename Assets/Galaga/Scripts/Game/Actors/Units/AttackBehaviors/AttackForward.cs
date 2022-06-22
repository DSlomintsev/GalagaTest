using Galaga.Game.Actors.Units.Parts;
using Galaga.Game.Actors.Weapons;
using UnityEngine;


namespace Galaga.Game.Actors.Units.AttackBehaviors
{
    public class AttackForward:IAttack,IUnitComponent
    {
        private Transform _transform;
        public Transform Transform
        {
            set => _transform = value;
        }
        
        private Weapon _weapon;
        

        public Weapon Weapon
        {
            set => _weapon = value;
        }

        public void Init()
        {
            _weapon.IsFirePressed.Value = true;
        }
        public void DeInit()
        {
            _weapon.IsFirePressed.Value = false;
        }
    }
}