using UnityEngine;

namespace Galaga.Common.Utils
{
    public static class ScreenUtils
    {
        public static bool IsViewPointInCameraRect(this Vector3 v3)
        {
            return v3.x <= 1f && v3.x >= 0f && v3.y <= 1f && v3.y >= 0f && v3.z >= 0f; 
        }
    }
}