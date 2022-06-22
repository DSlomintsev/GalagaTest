using Galaga.Game.Actors.Units.Parts;
using Galaga.Game.Commands;
using UnityEngine;
using Zenject;


namespace Galaga.Game.Actors.Bullets
{
    public class BulletCollider : MonoBehaviour
    {
        [Inject] public SignalBus SignalBus { get; set; }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            var attackable = collision.collider.GetComponent(typeof(IAttackable)) as IAttackable;
            if (attackable != null)
            {
                SignalBus.Fire(new HitUnitSignal { BulletCollider = this, Attackable = attackable });
            }
        }
    }
}