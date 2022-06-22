using Galaga.Common.Utils.Data;
using UnityEngine;


namespace Galaga.Game.Model
{
    public class GameModel
    {
        public ActiveData<bool> IsUI = new (true);
        public ActiveData<float> Score = new();
        public ActiveData<int> Level = new();
    }
}