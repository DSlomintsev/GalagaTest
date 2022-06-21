using Galaga.Common.Services.Dialog;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Galaga.MainMenu.UI.Dialogs.MainMenu
{
    public class SaveScoreDialogView : BaseDialogView
    {
        [SerializeField] private TMP_Text scoreLabel;
        [SerializeField] private TMP_InputField nameInput;
        [SerializeField] private Button continueBtn;
        
        private const string scoreLocale="Your score is ";

        private SaveScoreDialogViewModel _viewModel;
        public override BaseDialogViewModel ViewModel
        {
            set
            {
                base.ViewModel = value;

                if (_viewModel != null)
                {
                    _viewModel.Score.UpdateEvent -= UpdateScore;
                }
                _viewModel = (SaveScoreDialogViewModel)value;
                if (_viewModel != null)
                {
                    _viewModel.Score.UpdateEvent += UpdateScore;
                    UpdateScore(_viewModel.Score.Value);
                }
            }
        }

        private void UpdateScore(float scoreValue)
        {
            scoreLabel.text = $"{scoreLocale}{scoreValue}";
        }

        protected override void Init()
        {
            continueBtn.onClick.AddListener(OnContinueBtnClick);
        }
        
        protected override void DeInit()
        {
            continueBtn.onClick.RemoveListener(OnContinueBtnClick);
        }

        private void OnContinueBtnClick()
        {
            _viewModel.OnContinueGame(nameInput.text);
        }
    }
}