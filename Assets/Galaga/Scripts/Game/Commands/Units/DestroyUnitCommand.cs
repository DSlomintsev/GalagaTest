using Galaga.Common.UI;
using Galaga.Common.Utils;
using Galaga.Game.Actors.Units;
using Galaga.Game.Constants;
using Galaga.Game.Model;
using UnityEngine;
using Zenject;

namespace Galaga.Game.Commands
{
    public struct DestroyUnitSignal
    {
        public string Id { get; set; }
    }

    public class DestroyUnitCommand
    {
        [Inject] public UnitsModel UnitsModel { get; set; }
        [Inject] public GameModel GameModel { get; set; }
        [Inject] public WorldContainer WorldContainer { get; set; }

        public void Execute(DestroyUnitSignal signal)
        {
            var unit = UnitsModel.GetUnit(signal.Id);
            if (unit!=null)
            {
                var teamId = UnitsModel.GetTeamIdByUnitId(signal.Id);
                if (teamId != "Team0")
                {
                    GameModel.Score.Value += 1;
                }
                var hitEffect = SpawnUtils.Spawn<ParticleSystem>(ResourceConstants.ExplosionPrefab,
                    unit.Transform.position,unit.Transform.rotation, WorldContainer.Container);
                GameObject.Destroy(hitEffect,3);
                DestroyUnit(unit);
                UnitsModel.RemoveUnit(unit.Id);    
            }
        }
        
        private static void DestroyUnit(UnitController unit)
        {
            foreach (var component in unit.Components)
            {
                component.DeInit();
            }

            GameObject.Destroy(unit.Transform.gameObject);
        }
    }
}