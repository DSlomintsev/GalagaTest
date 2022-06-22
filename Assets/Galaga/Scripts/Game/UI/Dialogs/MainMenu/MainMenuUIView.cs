using Galaga.Common.Services.Dialog;
using UnityEngine;
using UnityEngine.UI;

namespace Galaga.MainMenu.UI.Dialogs.MainMenu
{
    public class MainMenuUIView : BaseDialogView
    {
        [SerializeField] private Button playGameBtn;
        [SerializeField] private Button openTopScoreBtn;
        [SerializeField] private Button quitGameBtn;

        private MainMenuUIViewModel _viewModel;
        public override BaseDialogViewModel ViewModel
        {
            set
            {
                base.ViewModel = value;
                _viewModel = (MainMenuUIViewModel)value;
            }
        }

        protected override void Init()
        {
            playGameBtn.onClick.AddListener(OnPlayGameBtnClick);
            openTopScoreBtn.onClick.AddListener(OnOpenTopScoreBtnClick);
            quitGameBtn.onClick.AddListener(OnQuitGameBtnClick);
        }
        
        protected override void DeInit()
        {
            playGameBtn.onClick.RemoveListener(OnPlayGameBtnClick);
            openTopScoreBtn.onClick.RemoveListener(OnOpenTopScoreBtnClick);
            quitGameBtn.onClick.RemoveListener(OnQuitGameBtnClick);
        }

        private void OnPlayGameBtnClick()
        {
            _viewModel.OnPlayGame();
        }

        private void OnOpenTopScoreBtnClick()
        {
            _viewModel.OnOpenTopScore();
        }
        
        private void OnQuitGameBtnClick()
        {
            _viewModel.OnQuitGame();
        }
    }
}