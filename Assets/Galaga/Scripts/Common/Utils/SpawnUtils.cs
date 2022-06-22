using UnityEngine;

namespace Galaga.Common.Utils
{
    public static class SpawnUtils
    {
        public static T Spawn<T>(string path, Transform parent = null) where T : Component
        {
            return GameObject.Instantiate(Resources.Load<T>(path),parent);
        }
        public static T Spawn<T>(string path, Vector3 pos, Quaternion rot, Transform parent = null) where T : Component
        {
            return GameObject.Instantiate(Resources.Load<T>(path),pos,rot,parent);
        }
        
        public static T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }
}