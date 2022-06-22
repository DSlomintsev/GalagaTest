using System.Collections.Generic;
using Galaga.Game.Actors.Units.Parts;
using UnityEngine;

namespace Galaga.Game.Actors.Units
{
    public class UnitController
    {
        public string Id { get; set; }
        public UnitData Data { get; set; }
        public Transform Transform;
        public List<IUnitComponent> Components = new ();
    }
}