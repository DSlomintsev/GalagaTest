using System;
using System.Collections.Generic;
using Zenject;

namespace Game.Services
{
    public class TickService:IInitializable,ITickable,IFixedTickable,ILateTickable,IDisposable
    {
        private List<Action> _tickableActions = new();
        private List<Action> _fixedTickableActions = new();
        private List<Action> _lateTickableActions = new();

        public void AddTickAction(Action action)
        {
            if (!_tickableActions.Contains(action))
                _tickableActions.Add(action);
        }
        
        public void RemoveTickAction(Action action)
        {
            if (_tickableActions.Contains(action))
                _tickableActions.Remove(action);
        }
        
        public void AddFixedTickAction(Action action)
        {
            if (!_fixedTickableActions.Contains(action))
                _fixedTickableActions.Add(action);
        }
        
        public void RemoveFixedTickAction(Action action)
        {
            if (_fixedTickableActions.Contains(action))
                _fixedTickableActions.Remove(action);
        }

        public void AddLateTickAction(Action action)
        {
            if (!_lateTickableActions.Contains(action))
                _lateTickableActions.Add(action);
        }

        public void RemoveLateTickAction(Action action)
        {
            if (_lateTickableActions.Contains(action))
                _lateTickableActions.Remove(action);
        }

        public void Initialize()
        {
            
        }

        public void Tick()
        {
            foreach (var action in _tickableActions)
                action();
        }

        public void FixedTick()
        {
            foreach (var action in _fixedTickableActions)
                action();
        }

        public void LateTick()
        {
            foreach (var action in _lateTickableActions)
                action();
        }

        public void Dispose()
        {
            _tickableActions.Clear();
            _fixedTickableActions.Clear();
            _lateTickableActions.Clear();
        }
    }
}