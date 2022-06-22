using System;
using UnityEngine;

namespace Galaga.Game.Commands.Data
{
    public static class PosTypeUtils
    {
        public static Vector2 ToVector2(this PosType type)
        {
            return type switch
            {
                PosType.NONE => Vector2.zero,
                PosType.CENTER_BOT => new Vector2(0,1),
                PosType.TOP_LEFT =>  new Vector2(-5,4),
                PosType.TOP_RIGHT => new Vector2(5,4),
                PosType.BOT_LEFT => new Vector2(-5,-4),
                PosType.BOT_RIGHT => new Vector2(5,-4),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}