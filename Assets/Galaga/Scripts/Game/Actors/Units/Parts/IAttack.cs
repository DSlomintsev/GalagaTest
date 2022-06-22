using Galaga.Game.Actors.Units.Parts;
using Galaga.Game.Actors.Weapons;
using Galaga.Game.Services.Input.Handlers;


namespace Galaga.Game.Actors.Units.AttackBehaviors
{
    public interface IAttack:IUnitComponent
    {
        public void Init();
        public void DeInit();
        public Weapon Weapon { set; }
    }
}