using System;
using System.Collections.Generic;
using Galaga.Common.UI;
using Galaga.Common.Utils;
using Galaga.Game.Model;
using UnityEngine;
using Zenject;


namespace Galaga.Common.Services.Dialog
{
    public class DialogService : IInitializable, IDisposable
    {
        [Inject] public UIContainer UIContainer { get; set; }
        [Inject] public DiContainer DiContainer { get; set; }
        [Inject] public GameModel GameModel { get; set; }

        private const string DialogsPath = "UI/Dialogs/";
        private const string ViewModelPostFix = "ViewModel";

        private List<DialogMVVM> _dialogs = new();

        public void Initialize()
        {
        }

        public void Dispose()
        {
        }

        public void OpenDialog<T>() where T : BaseDialogViewModel, new()
        {
            var viewName = typeof(T).Name.Replace(ViewModelPostFix, string.Empty);
            ;
            var path = $"{DialogsPath}{viewName}";
            var view = SpawnUtils.Spawn<BaseDialogView>(path, UIContainer.Container);
            var viewModel = new T();
            DiContainer.Inject(viewModel);

            view.ViewModel = viewModel;
            view.InitAnims(UIContainer.Container);

            var dialogMVVM = new DialogMVVM { View = view, ViewModel = viewModel };
            _dialogs.Add(dialogMVVM);

            view.Show();

            CheckIsAnyDialogPause();
        }

        public void CloseDialog<T>() where T : BaseDialogViewModel
        {
            for (var i = 0; i < _dialogs.Count; i++)
            {
                var dialogMVVM = _dialogs[i];
                var dialogVM = dialogMVVM.ViewModel as T;
                if (dialogVM != null)
                {
                    CloseDialog(dialogMVVM);
                    break;
                }
            }
        }

        public void CloseDialog(DialogMVVM dialogMVVM)
        {
            var view = dialogMVVM.View;
            view.HiddenEvent += OnViewHidden;
            view.Hide();

            _dialogs.Remove(dialogMVVM);
            CheckIsAnyDialogPause();
        }

        public bool IsAnyDialogPause
        {
            get
            {
                var result = false;
                for (var i = 0; i < _dialogs.Count; i++)
                {
                    if (_dialogs[i].View.IsPause)
                    {
                        result = true;
                        break;
                    }
                }

                return result;
            }
        }

        private void CheckIsAnyDialogPause()
        {
            GameModel.IsUI.Value = IsAnyDialogPause;
        }

        public bool IsDialogOpened<T>() where T : BaseDialogViewModel
        {
            var isResult = false;
            for (var i = 0; i < _dialogs.Count; i++)
            {
                var dialogMVVM = _dialogs[i];
                var dialog = dialogMVVM.ViewModel as T;
                if (dialog != null)
                {
                    isResult = true;
                    break;
                }
            }

            return isResult;
        }

        public void CloseLastOpenedDialog()
        {
            for (var i = _dialogs.Count-1; i >= 0; i--)
            {
                if (_dialogs[i].View.IsPause)
                {
                    CloseDialog(_dialogs[i]);
                    break;
                }
            }
        }

        public bool IsAnyDialogOpened => _dialogs.Count > 0;

        private void OnViewHidden(BaseDialogView view)
        {
            GameObject.Destroy(view.gameObject);
        }
    }

    public struct DialogMVVM
    {
        public BaseDialogView View;
        public BaseDialogViewModel ViewModel;
    }
}