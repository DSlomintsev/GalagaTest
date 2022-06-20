using UnityEngine;

namespace Galaga.Common.UI
{
    public class UIContainer : MonoBehaviour
    {
        [SerializeField] private RectTransform container;
        [SerializeField] private RectTransform dialogContainer;
        [SerializeField] private RectTransform systemContainer;
    
        public RectTransform Container=>container;
        public RectTransform DialogContainer=>container;
        public RectTransform SystemContainer=>container;
    }
}
