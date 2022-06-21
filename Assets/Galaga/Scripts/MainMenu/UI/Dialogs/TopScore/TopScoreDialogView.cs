using System.Collections.Generic;
using Galaga.Common.Services.Dialog;
using Galaga.MainMenu.Services.TopScore;
using UnityEngine;
using UnityEngine.UI;


namespace Galaga.MainMenu.UI.Dialogs.TopScore
{
    public class TopScoreDialogView:BaseDialogView
    {
        [SerializeField] private RectTransform itemsContainer;
        [SerializeField] private Button closeBtn;
        [SerializeField] private TopScoreItemView itemPrefab;

        private List<TopScoreItemView> _items = new();

        private TopScoreDialogViewModel _viewModel;
        public override BaseDialogViewModel ViewModel
        {
            set
            {
                if (_viewModel != null)
                {
                    _viewModel.Score.UpdateEvent -= UpdateScore;
                }
                _viewModel = (TopScoreDialogViewModel)value;
                if (_viewModel != null)
                {
                    _viewModel.Score.UpdateEvent += UpdateScore;
                    UpdateScore(_viewModel.Score.Value);
                }
            }
        }

        private void Awake()
        {
            itemPrefab.gameObject.SetActive(false);
        }

        private void UpdateScore(List<TopScoreItemData> items)
        {
            ClearItems();
            foreach (var data in _viewModel.Score.Value)
            {
                var item = GameObject.Instantiate(itemPrefab,itemsContainer);
                item.gameObject.SetActive(true);
                item.SetData(data);
                _items.Add(item);
            }
        }

        private void ClearItems()
        {
            foreach (var item in _items)
            {
                GameObject.Destroy(item.gameObject);
            }
            _items.Clear();
        }

        protected override void Init()
        {
            closeBtn.onClick.AddListener(OnCloseBtnClick);
        }
    
        protected override void DeInit()
        {
            closeBtn.onClick.RemoveListener(OnCloseBtnClick);
            ViewModel = null;
        }

        private void OnCloseBtnClick()
        {
            _viewModel.Close();
        }
    }
}
