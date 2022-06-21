using System;
using Galaga.Common.Utils;
using UnityEngine;


namespace Galaga.Common.Services.Dialog
{
    public class BaseDialogView : MonoBehaviour
    {
        [SerializeField] private RectTransform container;
        [SerializeField] private bool isPause;
        [SerializeField] private UIAnim[] showAnims;
        [SerializeField] private UIAnim[] hideAnims;

        public bool IsPause => isPause;

        private Vector2 _defaultPos;
        private Vector2 _hiddenPos;
        public event Action<BaseDialogView> HiddenEvent;

        public virtual BaseDialogViewModel ViewModel { get; set; }

        private void Awake()
        {
            container = gameObject.GetComponent<RectTransform>();
            container.gameObject.SetActive(false);
        }
        
        protected virtual void Init()
        {

        }

        protected virtual void DeInit()
        {

        }

        public void Show()
        {
            container.gameObject.SetActive(true);
            hideAnims.StopAnims();
            showAnims.PlayAnims();

            Init();
        }

        public void Hide()
        {
            showAnims.StopAnims();

            if (hideAnims.Length > 0)
            {
                hideAnims.PlayAnims();
                hideAnims[0].AnimEndEvent += OnHide;    
            }
            else
            {
                OnHide();
            }
        }

        private void OnHide()
        {
            DeInit();

            if (hideAnims.Length > 0)
            {
                hideAnims[0].AnimEndEvent -= OnHide;
            }
            container.gameObject.SetActive(false);
            HiddenEvent.Call(this);
        }

        public void InitAnims(RectTransform canvasRectTransform)
        {
            foreach (var anim in showAnims)
            {
                anim.Init(canvasRectTransform);
            }
            foreach (var anim in hideAnims)
            {
                anim.Init(canvasRectTransform);
            }
        }

        
    }
}