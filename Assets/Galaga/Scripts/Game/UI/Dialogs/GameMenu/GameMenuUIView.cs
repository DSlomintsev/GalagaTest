using Galaga.Common.Services.Dialog;
using UnityEngine;
using UnityEngine.UI;

namespace Galaga.MainMenu.UI.Dialogs.MainMenu
{
    public class GameMenuUIView : BaseDialogView
    {
        [SerializeField] private Button continueGameBtn;
        [SerializeField] private Button quitGameBtn;

        private GameMenuUIViewModel _viewModel;
        public override BaseDialogViewModel ViewModel
        {
            set
            {
                base.ViewModel = value;
                _viewModel = (GameMenuUIViewModel)value;
            }
        }

        protected override void Init()
        {
            continueGameBtn.onClick.AddListener(OnPlayGameBtnClick);
            quitGameBtn.onClick.AddListener(OnQuitGameBtnClick);
        }
        
        protected override void DeInit()
        {
            continueGameBtn.onClick.RemoveListener(OnPlayGameBtnClick);
            quitGameBtn.onClick.RemoveListener(OnQuitGameBtnClick);
        }

        private void OnPlayGameBtnClick()
        {
            _viewModel.OnContinueGame();
        }

        private void OnQuitGameBtnClick()
        {
            _viewModel.OnQuitGame();
        }
    }
}