
using Galaga.Game.Model;
using Galaga.Game.Services.Input;
using UnityEngine;
using Zenject;

namespace Galaga.Infrastructure.States
{
    public class AppLoopState : IState
    {
        [Inject] public AppStateMachine AppStateMachine { get; set; }
        [Inject] public GameModel GameModel { get; set; }
        [Inject] public InputService InputService { get; set; }

        public void Enter()
        {
            Debug.Log("ENTER APP LOOP");
            GameModel.IsUI.Value = false;
            InputService.PlayerInputHandler.IsFire.UpdateEvent += OnIsFireUpdate;
        }

        private void OnIsFireUpdate(bool obj)
        {
            Debug.Log("OnIsFireUpdate");
        }

        public void Exit()
        {
        }
    }
}