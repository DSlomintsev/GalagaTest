using Galaga.Common.UI;
using Galaga.Common.Utils;
using Galaga.Game.Actors.Bullets;
using UnityEngine;
using Zenject;


namespace Galaga.Game.Commands
{
    public struct ShotSignal
    {
        public string TeamId { get; set; }
        public Vector2 Pos { get; set; }
        public Quaternion Dir { get; set; }
    }

    public class ShotCommand
    {
        [Inject] public WorldContainer WorldContainer { get; set; }
        [Inject] public SignalBus SignalBus { get; set; }
        [Inject] public DiContainer DiContainer { get; set; }
        public void Execute(ShotSignal signal)
        {
            var transform = SpawnUtils.Spawn<Transform>("Prefabs/Bullets/Bullet", 
                signal.Pos,signal.Dir,WorldContainer.transform);
            transform.gameObject.layer = LayerMask.NameToLayer(signal.TeamId);
            Debug.Log(signal.Dir.eulerAngles);
            var rb = transform.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(signal.Dir.eulerAngles*1, ForceMode2D.Impulse);
            var bulletCollider = transform.gameObject.AddComponent<BulletCollider>();
            DiContainer.Inject(bulletCollider);
        }
    }

    
}