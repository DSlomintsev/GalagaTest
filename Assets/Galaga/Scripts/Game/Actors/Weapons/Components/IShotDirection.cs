using UnityEngine;

namespace Galaga.Game.Actors.Weapons.Components
{
    public interface IShotDirection
    {
        public void Shot();
        public void ResetDir();
        public Quaternion GetDir();
    }
}