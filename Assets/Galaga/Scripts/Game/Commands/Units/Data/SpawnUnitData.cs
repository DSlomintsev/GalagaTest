using System.Collections.Generic;
using Galaga.Game.Actors.Weapons;

namespace Galaga.Game.Commands.Data
{
    public struct SpawnUnitData
    {
        public string UnitId { get; set; }
        public string SkinId { get; set; }
        public float Health { get; set; }
        public string TeamId { get; set; }
        public PosType StartPos { get; set; }
        public AttackType AttackType { get; set; }
        public MoveType MoveType { get; set; }
        public float Speed { get; set; }
        public List<PosType> Points { get; set; }
        public WeaponConfig WeaponConfig { get; set; }

        public override string ToString()
        {
            var str = base.ToString();
            str += $"SkinId={SkinId}\n";
            str += $"TeamId={TeamId}\n";
            str += $"StartPos={StartPos}\n";
            str += $"AttackType={AttackType}\n";
            str += $"MoveType={MoveType}\n";
            str += $"Points={Points}\n";
            str += $"WeaponConfig={WeaponConfig}\n";
            return str;
        }
    }
    
    public enum PosType
    {
        NONE,
        CENTER_BOT,
        TOP_LEFT,
        TOP_RIGHT,
        BOT_LEFT,
        BOT_RIGHT
    }
    public enum AttackType
    {
        NONE,
        PLAYER,
        TARGET,
        AUTO
    }
    
    public enum MoveType
    {
        NONE,
        PLAYER,
        POINTS
    }
}