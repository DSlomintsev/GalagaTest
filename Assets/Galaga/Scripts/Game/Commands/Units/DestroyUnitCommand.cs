using Galaga.Game.Actors.Units;
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

        public void Execute(DestroyUnitSignal signal)
        {
            var unit = UnitsModel.GetUnit(signal.Id);
            DestroyUnit(unit);
            UnitsModel.RemoveUnit(unit.Id);
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