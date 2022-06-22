using Unity.Mathematics;
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
            var rotation = Transform.eulerAngles;
            Debug.Log(rotation);
            rotation = new Vector3(0, 1);
            return quaternion.Euler(rotation);
        }
    }
}