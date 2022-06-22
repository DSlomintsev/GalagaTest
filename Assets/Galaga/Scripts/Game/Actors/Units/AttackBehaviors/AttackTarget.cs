using Galaga.Game.Actors.Weapons;
using Galaga.Game.Services.Input.Handlers;


namespace Galaga.Game.Actors.Units.AttackBehaviors
{
    public class AttackTarget:IAttack
    {
        public void Init()
        {
            throw new System.NotImplementedException();
        }

        public void DeInit()
        {
            throw new System.NotImplementedException();
        }

        public Weapon Weapon { get; set; }
    }
}