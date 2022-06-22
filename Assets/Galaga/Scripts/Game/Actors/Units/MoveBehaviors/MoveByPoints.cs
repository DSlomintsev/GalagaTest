using System.Collections.Generic;
using Galaga.Game.Actors.Units.Parts;
using Game.Services;
using UnityEngine;
using Zenject;


namespace Galaga.Game.Actors.Units.MoveBehaviors
{
    public class MoveByPoints:IMovable
    {
        [Inject] public TickService TickService { get; set; }

        public void Init()
        {
            TickService.AddFixedTickAction(FixedTick);
        }

        public void DeInit()
        {
            TickService.RemoveFixedTickAction(FixedTick);
        }
        
        private float _speed = 0;
        public float Speed
        {
            set => _speed = value;
        }

        private Rigidbody2D _rigidbody;
        public Rigidbody2D Rigidbody
        {
            set => _rigidbody = value;
        }

        private List<Vector2> _points;
        public List<Vector2> Points
        {
            set => _points = value;
        }

        private int _currentIndex;

        private void FixedTick()
        {
            var pos = _rigidbody.position;
            var point = _points[_currentIndex];
            var dir = point - pos;
            if (dir.sqrMagnitude <= 1)
            {
                _currentIndex++;
                if (_currentIndex == _points.Count)
                    _currentIndex = 0;
            }

            _rigidbody.velocity = dir.normalized * _speed;
        }
    }
}