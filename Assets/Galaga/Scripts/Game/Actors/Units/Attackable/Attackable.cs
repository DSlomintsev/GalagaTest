using Galaga.Game.Actors.Units.Parts;
using UnityEngine;


namespace Galaga.Game.Actors.Units.Attackable
{
    public class Attackable:MonoBehaviour, IUnitComponent, IAttackable
    {
        private string _id;
        public string Id
        {
            get => _id;
            set => _id = value;
        }
        
        private float _health;
        public float Health { get; set; }
        public void Init()
        {
        }

        public void DeInit()
        {
        }
    }
}