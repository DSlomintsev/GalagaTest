using System.Collections.Generic;
using Galaga.Common.Utils.Data;
using UnityEngine;

namespace Galaga.Game.Model
{
    public class GameModel
    {
        public Transform World { get; set; }

        public ActiveData<bool> IsUI = new (true);
        public ActiveData<float> Score = new();
    }
}