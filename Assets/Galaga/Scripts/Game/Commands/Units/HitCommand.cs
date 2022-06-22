using Galaga.Game.Actors.Bullets;
using Galaga.Game.Actors.Units.Parts;
using Galaga.Game.Model;
using UnityEngine;
using Zenject;

namespace Galaga.Game.Commands
{
    public struct HitUnitSignal
    {
        public BulletCollider BulletCollider { get; set; }
        public IAttackable Attackable { get; set; }
    }

    public class HitUnitCommand
    {
        [Inject] public SignalBus SignalBus { get; set; }
        [Inject] public UnitsModel UnitsModel { get; set; }
        public void Execute(HitUnitSignal signal)
        {
            GameObject.Destroy(signal.BulletCollider.gameObject);
            
            signal.Attackable.Health -= 1;
            if (signal.Attackable.Health <= 0)
            {
                SignalBus.Fire(new DestroyUnitSignal{Id=signal.Attackable.Id});
                
            }
        }
    }
}