using Galaga.Common.Services.Dialog;
using UnityEngine;
using UnityEngine.UI;


namespace Galaga.MainMenu.UI.Dialogs.TopScore
{
    public class TopScoreDialogView:BaseDialogView
    {
        [SerializeField] private RectTransform itemsContainer;
        [SerializeField] private Button closeBtn;
        [SerializeField] private TopScoreItemView itemPrefab;

        private TopScoreDialogViewModel _viewModel;
        public override BaseDialogViewModel ViewModel
        {
            set
            {
                base.ViewModel = value;
                _viewModel = (TopScoreDialogViewModel)value;
            }
        }

        protected override void Init()
        {
            closeBtn.onClick.AddListener(OnCloseBtnClick);
        }
    
        protected override void DeInit()
        {
            closeBtn.onClick.RemoveListener(OnCloseBtnClick);
        }

        private void OnCloseBtnClick()
        {
            _viewModel.Close();
        }
    }
}
