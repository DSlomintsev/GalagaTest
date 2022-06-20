using Galaga.Game.Model;
using UnityEngine.InputSystem;
using Zenject;

namespace Galaga.Game.Services.Input.Handlers
{
    public class UIInputHandler:InputHandlerBase
    {
        [Inject] public GameModel GameModel { get; set; }
        protected override void OnStart()
        {
            //Input.actions["UI"].performed += OnUI;
        }
        
        protected override void OnStop()
        {
            //Input.actions["UI"].performed -= OnUI;
        }
        
        /*private void OnUI(InputAction.CallbackContext obj)
        {
            GameModel.IsUI.Value = !GameModel.IsUI.Value;
        }*/
    }
}