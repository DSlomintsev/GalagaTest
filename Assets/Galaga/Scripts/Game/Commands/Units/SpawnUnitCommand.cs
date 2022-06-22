using System;
using System.Collections.Generic;
using Galaga.Common.UI;
using Galaga.Common.Utils;
using Galaga.Game.Actors.Units;
using Galaga.Game.Actors.Units.Attackable;
using Galaga.Game.Actors.Units.AttackBehaviors;
using Galaga.Game.Actors.Units.Parts;
using Galaga.Game.Actors.Weapons;
using Galaga.Game.Actors.Weapons.Components;
using Galaga.Game.Commands.Data;
using Galaga.Game.Model;
using Galaga.Game.Services.Input;
using UnityEngine;
using UnityEngine.Animations;
using Zenject;


namespace Galaga.Game.Commands
{
    public struct SpawnUnitSignal
    {
        public SpawnUnitData Data { get; set; }
    }

    public class SpawnUnitCommand
    {
        [Inject] public WorldContainer WorldContainer { get; set; }
        [Inject] public UnitsModel UnitsModel { get; set; }
        [Inject] public InputService InputService { get; set; }
        [Inject] public DiContainer DiContainer { get; set; }
        
        public void Execute(SpawnUnitSignal signal)
        {
            if (signal.Data.TeamId == "Team1") return;
            var data = signal.Data;
            
            var transform = AddModel(data);
            
            var unitController = new UnitController();
            unitController.Id = data.UnitId;
            unitController.Transform = transform;
            
            var weapon = CreateWeapon(transform,data.TeamId,data.WeaponConfig);
            
            AddAttackable(transform, data, unitController.Components);
            AddAttack(transform, data, weapon, unitController.Components);
            AddMove(transform, data,unitController.Components);
            
            UnitsModel.GetTeam(data.TeamId).Units.Add(unitController);
        }

        private void AddAttackable(Transform transform, SpawnUnitData data, List<IUnitComponent> components)
        {
            if (data.Health > 0)
            {
                var attackable = transform.gameObject.AddComponent<Attackable>();
                attackable.Health = data.Health;
                attackable.Id = data.UnitId;
                components.Add(attackable);    
            }
        }

        private Transform AddModel(SpawnUnitData data)
        {
            var transform = SpawnUtils.Spawn<Transform>("Prefabs/Units/"+data.SkinId,WorldContainer.Container);
            transform.gameObject.layer = LayerMask.NameToLayer(data.TeamId);
            transform.position = data.StartPos.ToVector2();
            return transform;
        }

        private void AddAttack(Transform transform, SpawnUnitData data, Weapon weapon, List<IUnitComponent> components)
        {
            if (data.AttackType == AttackType.NONE) return;

            IAttack attack = null;
            switch (data.AttackType)
            {
                case AttackType.NONE:
                    break;
                case AttackType.PLAYER:
                    attack = SpawnUnitUtils.AddAttackByPlayerInput(InputService);
                    break;
                case AttackType.AUTO:
                    attack = SpawnUnitUtils.AddAttackForward(transform);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            DiContainer.Inject(attack);
            attack.Weapon = weapon;
            attack.Init();
            components.Add(attack);
        }

        private void AddMove(Transform transform, SpawnUnitData data, List<IUnitComponent> components)
        {
            if(data.MoveType == MoveType.NONE) return;
            
            IMovable move = null;
            switch (data.MoveType)
            {
                case MoveType.NONE:
                    break;
                case MoveType.PLAYER:
                    move=SpawnUnitUtils.AddMoveByPlayer(transform,data.Speed, InputService);
                    break;
                case MoveType.POINTS:
                    var points = new List<Vector2>();
                    foreach (var posType in data.Points)
                    {
                        points.Add(posType.ToVector2());
                    }
                    move=SpawnUnitUtils.AddMoveByPoints(transform,data.Speed, points);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            DiContainer.Inject(move);
            move.Init();
            components.Add(move);
        }

        private Weapon CreateWeapon(Transform transform, string teamId, WeaponConfig config)
        {
            var weapon = new Weapon();
            weapon.TeamId = teamId;
            weapon.Config = config;

            IPositionContainer posContainer=null;
            switch (config.PositionType)
            {
                case PositionType.NONE:
                    break;
                case PositionType.TRANSFORM:
                    posContainer=new TargetContainer{Transform = transform};
                    break;
                case PositionType.POSITION:
                    posContainer = new PositionContainer { Position = Vector3.zero };
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            weapon.PositionContainer = posContainer;

            IShotDirection shotDir = null;
            
            weapon.ShotDir = new ShotForward{Transform = transform};
            DiContainer.Inject(weapon);
            weapon.Init();
            return weapon;
        }
    }

    public interface IPositionContainer
    {
        public Vector2 Pos { get; }
    }

    public class TargetContainer:IPositionContainer
    {
        public Transform Transform { get; set; }
        public Vector2 Pos => Transform.position;
    }
    
    public class PositionContainer:IPositionContainer
    {
        public Vector2 Position { get; set; }
        public Vector2 Pos => Position;
    }
    
    public class MouseCursorContainer:IPositionContainer
    {
        private Vector2 mousePos;
        public Vector2 Pos { get; }
    }

    //mouse dir
    //unit dir
    //random dir
    //forward dir
    //arc dir

    public class WeaponDirection
    {
        public void Shot()
        {
            
        }

        /*public Quaternion GetDir()
        {
            
        }*/
    }
}