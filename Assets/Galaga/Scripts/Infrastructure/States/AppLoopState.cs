
using Galaga.Common.Services.Dialog;
using Galaga.Game.Model;
using Galaga.Game.Services.Input;
using Galaga.MainMenu.UI.Dialogs.MainMenu;
using UnityEngine;
using Zenject;

namespace Galaga.Infrastructure.States
{
    public class AppLoopState : IState
    {
        [Inject] public AppStateMachine AppStateMachine { get; set; }
        [Inject] public GameModel GameModel { get; set; }
        [Inject] public InputService InputService { get; set; }
        [Inject] public SignalBus SignalBus { get; set; }
        [Inject] public DialogService DialogService { get; set; }

        public void Enter()
        {
            GameModel.IsUI.Value = false;
            InputService.PlayerInputHandler.IsFire.UpdateEvent += OnIsFireUpdate;
            InputService.UIInputHandler.Escape += OnEscapeClick;
            InputService.PlayerInputHandler.Escape += OnEscapeClick;
            DialogService.OpenDialog<GameUIViewModel>();
        }
        
        public void Exit()
        {
            InputService.PlayerInputHandler.IsFire.UpdateEvent -= OnIsFireUpdate;
            InputService.UIInputHandler.Escape -= OnEscapeClick;
            InputService.PlayerInputHandler.Escape -= OnEscapeClick;
            DialogService.CloseDialog<GameUIViewModel>();
        }

        private void OnEscapeClick()
        {
            if (DialogService.IsAnyDialogPause)
            {
                DialogService.CloseLastOpenedDialog();
            }
            else
            {
                DialogService.OpenDialog<GameMenuUIViewModel>();
            }
        }

        private void OnIsFireUpdate(bool obj)
        {
            Debug.Log("OnIsFireUpdate");
        }
    }
}