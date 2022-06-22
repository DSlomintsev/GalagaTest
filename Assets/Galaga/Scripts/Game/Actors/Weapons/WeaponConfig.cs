namespace Galaga.Game.Actors.Weapons
{
    public enum PositionType
    {
        NONE,
        TRANSFORM,
        POSITION
    }
    
    public enum DirectionType
    {
        NONE,
        FORWARD,
        MOUSE
    }
    
    public enum ShotModifier
    {
        NONE,
        FORWARD,
        RANDOM,
        ARC
    }

    public struct WeaponConfig
    {
        public int Pellets { get; set; }
        public float CooldownTime { get; set; }
        public float Damage { get; set; }
        public float BulletSpeed { get; set; }
        public PositionType PositionType { get; set; }
        public DirectionType DirectionType { get; set; }
        public ShotModifier ShotModifier { get; set; }
    }
}