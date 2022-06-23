using Galaga.Common.Services.SoundPlayer;
using Galaga.Common.UI;
using Galaga.Common.Utils;
using Galaga.Game.Actors.Bullets;
using Galaga.Game.Actors.Units.Parts;
using Galaga.Game.Constants;
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
        [Inject] public SoundService SoundService { get; set; }
        [Inject] public WorldContainer WorldContainer { get; set; }
        
        public void Execute(HitUnitSignal signal)
        {
            var bullet = signal.BulletCollider.transform;
            
            SoundService.PlaySound(SoundConstants.Hit);
            var hitEffect = SpawnUtils.Spawn<ParticleSystem>(ResourceConstants.HitPrefab,
                bullet.position,bullet.rotation, WorldContainer.Container);
            GameObject.Destroy(hitEffect,3);

            GameObject.Destroy(bullet.gameObject);
            
            signal.Attackable.Health -= 1;
            if (signal.Attackable.Health <= 0)
            {
                SignalBus.Fire(new DestroyUnitSignal{Id=signal.Attackable.Id});
            }
        }
    }
}