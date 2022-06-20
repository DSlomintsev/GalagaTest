using System;
using System.Collections.Generic;
using Galaga.Common.UI;
using Galaga.Common.Utils;
using UnityEngine;
using Zenject;


namespace Galaga.Common.Services.Dialog
{
    public class DialogService:IInitializable, IDisposable
    {
        [Inject] public UIContainer UIContainer { get; set; }
        [Inject] public DiContainer DiContainer { get; set; }

        private const string DialogsPath = "UI/Dialogs/";
        private const string ViewPostFix = "View";

        private List<DialogMVVM> _dialogs = new();
        
        public void Initialize()
        {
        }

        public void Dispose()
        {
        }
        
        public DialogMVVM OpenDialog<V,VM>() where V:BaseDialogView,new() where VM:BaseDialogViewModel, new()
        {
            var viewName = typeof(V).Name.Replace(ViewPostFix, string.Empty);;
            var path = $"{DialogsPath}{viewName}";
            var view = SpawnUtils.Spawn<V>(path,UIContainer.Container);
            var viewModel = new VM();
            DiContainer.Inject(viewModel);

            view.ViewModel = viewModel;
            view.InitAnims(UIContainer.Container);
            
            var dialogMVVM = new DialogMVVM { View = view, ViewModel = viewModel };
            _dialogs.Add(dialogMVVM);
            
            view.Show();

            return dialogMVVM;
        }

        public void CloseDialog<VM>() where VM:BaseDialogViewModel, new()
        {
            for (var i = 0; i < _dialogs.Count; i++)
            {
                var dialogMVVM = _dialogs[i];
                var dialog = dialogMVVM.ViewModel as VM;
                if (dialog != null)
                {
                    var view = dialogMVVM.View;
                    view.HiddenEvent += OnViewHidden;
                    view.Hide();
                    
                    _dialogs.Remove(dialogMVVM);
                    
                    break;
                }
            }
        }

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