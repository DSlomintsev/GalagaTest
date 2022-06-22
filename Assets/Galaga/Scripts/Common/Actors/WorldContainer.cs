using UnityEngine;

namespace Galaga.Common.UI
{
    public class WorldContainer : MonoBehaviour
    {
        [SerializeField] private Transform container;
    
        public Transform Container=>container;
    }
}
