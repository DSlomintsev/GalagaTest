using Galaga.Common.Services.Dialog;
using TMPro;
using UnityEngine;


namespace Galaga.MainMenu.UI.Dialogs.MainMenu
{
    public class GameUIView : BaseDialogView
    {
        [SerializeField] private TMP_Text score;
        
        private const string scoreLocale="Score: ";

        private GameUIViewModel _viewModel;
        public override BaseDialogViewModel ViewModel
        {
            set
            {
                base.ViewModel = value;

                if (_viewModel != null)
                {
                    _viewModel.Score.UpdateEvent -= UpdateScore;
                }
                _viewModel = (GameUIViewModel)value;
                if (_viewModel != null)
                {
                    _viewModel.Score.UpdateEvent += UpdateScore;
                    UpdateScore(_viewModel.Score.Value);
                }
            }
        }

        private void UpdateScore(float scoreValue)
        {
            score.text = $"{scoreLocale}{scoreValue}";
        }

        protected override void Init()
        {
            
        }
        
        protected override void DeInit()
        {
            ViewModel = null;
        }
    }
}