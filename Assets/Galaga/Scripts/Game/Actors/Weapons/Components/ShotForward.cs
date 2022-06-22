using UnityEngine;


namespace Galaga.Game.Actors.Weapons.Components
{
    public class ShotForward:IShotDirection
    {
        public Transform Transform { get; set; }
        public void Shot()
        {
        }

        public void ResetDir()
        {
        }

        public Quaternion GetDir()
        {
            return Transform.rotation;
        }
    }
}