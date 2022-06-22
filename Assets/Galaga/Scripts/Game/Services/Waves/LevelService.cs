using System;
using Actions;
using Galaga.Common.Utils;
using Galaga.Game.Actors.Units;
using Galaga.Game.Commands;
using Galaga.Game.Constants;
using Galaga.Game.Model;
using Galaga.MainMenu.Commands;
using UnityEngine;
using Zenject;


namespace Galaga.MainMenu.Services.Waves
{
    public class LevelService : IInitializable, IDisposable
    {
        [Inject] public DiContainer DiContainer { get; set; }
        [Inject] public UnitsModel UnitsModel { get; set; }
        [Inject] public GameModel GameModel { get; set; }
        [Inject] public SignalBus SignalBus { get; set; }

        private int _currentLevel;
        private int _totalLevels;

        private ActionController _actionController;
        
        public void Initialize()
        {
            _totalLevels = Resources.LoadAll<TextAsset>(ResourceConstants.Levels).Length;
        }

        public void Dispose()
        {
        }

        public void PlayLevel()
        {
            GameModel.Score.Value = 0;
            var levelDataStr = SpawnUtils.Load<TextAsset>(ResourceConstants.Levels + "Level"+_currentLevel).text;
            var actionData = ActionUtils.JSONToData(levelDataStr);
            _actionController = new ActionController(actionData);
            DiContainer.Inject(_actionController);
            _actionController.Play(0);
        }

        public void LevelFinished()
        {
            StopLevel();
            _currentLevel++;
            if (_currentLevel >= _totalLevels)
            {
                _currentLevel = 0;
                SignalBus.Fire<GoToMainMenuSignal>();
            }
            else
            {
                PlayLevel();
            }
        }
        
        public void StopLevel()
        {
            _actionController?.Stop();
            _actionController = null;

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