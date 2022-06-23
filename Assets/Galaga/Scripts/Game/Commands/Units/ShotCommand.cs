using Galaga.Common.Services.SoundPlayer;
using Galaga.Common.UI;
using Galaga.Common.Utils;
using Galaga.Game.Actors.Bullets;
using Galaga.Game.Constants;
using UnityEngine;
using Zenject;


namespace Galaga.Game.Commands
{
    public struct ShotSignal
    {
        public string TeamId { get; set; }
        public float BulletSpeed { get; set; }
        public Vector2 Pos { get; set; }
        public Quaternion Dir { get; set; }
    }

    public class ShotCommand
    {
        [Inject] public WorldContainer WorldContainer { get; set; }
        [Inject] public SignalBus SignalBus { get; set; }
        [Inject] public SoundService SoundService { get; set; }
        [Inject] public DiContainer DiContainer { get; set; }
        public void Execute(ShotSignal signal)
        {
            var transform = SpawnUtils.Spawn<Transform>(ResourceConstants.Bullet, 
                signal.Pos,signal.Dir,WorldContainer.transform);
            SoundService.PlaySound(SoundConstants.Shot);
            transform.gameObject.layer = LayerMask.NameToLayer(signal.TeamId);
            var rb = transform.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(signal.Dir*Vector3.right*signal.BulletSpeed, ForceMode2D.Impulse);
            var bulletCollider = transform.gameObject.AddComponent<BulletCollider>();
            DiContainer.Inject(bulletCollider);
            GameObject.Destroy(transform.gameObject, 10);
        }
    }

    
}