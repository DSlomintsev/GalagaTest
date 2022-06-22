using System.Collections.Generic;
using Galaga.Game.Actors.Units.AttackBehaviors;
using Galaga.Game.Actors.Units.MoveBehaviors;
using Galaga.Game.Services.Input;
using UnityEngine;
using Zenject;


namespace Galaga.Game.Commands
{
    public static class SpawnUnitUtils
    {
        public static MoveByPoints AddMoveByPoints(Transform transform,float speed, List<Vector2> points)
        {
            var movable = new MoveByPoints();
            movable.Rigidbody = transform.GetComponent<Rigidbody2D>();
            movable.Points = points;
            movable.Speed = speed;
            return movable;
        }

        public static MoveByPlayerInput AddMoveByPlayer(Transform transform, float speed, InputService inputService)
        {
            var movable = new MoveByPlayerInput();
            movable.PlayerInputHandler = inputService.PlayerInputHandler;
            movable.Rigidbody = transform.GetComponent<Rigidbody2D>();
            movable.Speed = speed;
            return movable;
        }

        public static AttackByPlayerInput AddAttackByPlayerInput(InputService inputService)
        {
            var attackComponent = new AttackByPlayerInput();
            attackComponent.PlayerInputHandler = inputService.PlayerInputHandler;
            attackComponent.Camera = Camera.main;
            return attackComponent;
        }

        public static AttackForward AddAttackForward()
        {
            var attackComponent = new AttackForward();
            return attackComponent;
        }
        
        public static AttackTarget AddAttackTarget(Transform targetTransform)
        {
            var attackComponent = new AttackTarget();
            attackComponent.Target = targetTransform;  
            return attackComponent;
        }
    }
}