using UnityEngine;

namespace Galaga.Common.Utils
{
    public static class Vector3Ext
    {
        public static Vector3 ToInt(this Vector3 v)
        {
            return new Vector3(Mathf.Ceil(v.x), Mathf.Ceil(v.y), Mathf.Ceil(v.z));
        }

        public static Vector3 ToV3XZ(this Vector3 v)
        {
            return new Vector3(v.x, 0, v.z);
        }

        public static Vector3 ToV3X(this Vector3 v)
        {
            return new Vector3(v.x, 0, 0);
        }

        public static Vector3 ToV3Y(this Vector3 v)
        {
            return new Vector3(0, v.y, 0);
        }

        public static Vector3 ToV3Z(this Vector3 v)
        {
            return new Vector3(0, 0, v.z);
        }
    }
}