using UnityEngine;

namespace Galaga.Common.Utils
{
    public static class Vector2Ext
    {
        public static Vector3 ToV3XZ(this Vector2 v)
        {
            return new Vector3(v.x, 0, v.y);
        }
    }
}