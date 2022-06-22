using System;
using Actions;
using Galaga.Common.Utils;
using Galaga.Game.Actors.Units;
using Galaga.Game.Commands;
using Galaga.Game.Model;
using UnityEngine;
using Zenject;


namespace Galaga.MainMenu.Services.Waves
{
    public class LevelService : IInitializable, IDisposable
    {
        [Inject] public DiContainer DiContainer { get; set; }
        [Inject] public UnitsModel UnitsModel { get; set; }
        [Inject] public SignalBus SignalBus { get; set; }

        private ActionController _actionController;
        
        public void Initialize()
        {
        }

        public void Dispose()
        {
        }

        public void PlayLevel(string levelId)
        {
            var levelDataStr = SpawnUtils.Load<TextAsset>("Levels/" + levelId).text;
            var actionData = ActionUtils.JSONToData(levelDataStr);
            _actionController = new ActionController(actionData);
            DiContainer.Inject(_actionController);
            _actionController.Play(0);
        }
        
        public void StopLevel()
        {
            _actionController.Stop();
            _actionController = null;
            
            Debug.Log(UnitsModel.Teams.Count);
            
            foreach (var team in UnitsModel.Teams)
            {
                while (team.Units.Count>0)
                {
                    SignalBus.Fire(new DestroyUnitSignal{Id=team.Units[^1].Id});
                }   
                team.Units.Clear();
            }
            UnitsModel.Teams.Clear();
        }
    }
}