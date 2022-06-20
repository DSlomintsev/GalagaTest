using Galaga.Common.Services.Dialog;
using UnityEngine;


namespace Galaga.Infrastructure.Loading
{
    public class LoadingSceneAnim : BaseDialogView
    {
        public void Awake()
        {
            InitAnims(GetComponent<RectTransform>());
        }
    }
}