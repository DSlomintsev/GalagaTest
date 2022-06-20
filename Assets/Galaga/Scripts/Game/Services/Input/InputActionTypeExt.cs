namespace Galaga.Game.Services.Input
{
    public static class InputActionTypeExt
    {
        public static string ToStr(this InputActionType type)
        {
            return type switch
            {
                InputActionType.PLAYER => "Player",
                InputActionType.UI => "UI"
            };
        }
    }
}