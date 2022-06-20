using System.Collections.Generic;
using Galaga.Common.Utils.Data;
using UnityEngine;

namespace Galaga.Game.Model
{
    public class GameModel
    {
        public Transform World { get; set; }

        public ActiveData<bool> IsLevel = new (false);
        public ActiveData<bool> IsPlayer = new ();
        public ActiveData<bool> IsUI = new (true);
        
        public ActiveData<GameState> GameState = new ();

        public List<GameObject> Items = new();
        public GameObject Land = new();
    }
}