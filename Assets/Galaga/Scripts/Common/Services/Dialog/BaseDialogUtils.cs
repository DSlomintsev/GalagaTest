namespace Galaga.Common.Services.Dialog
{
    public static class BaseDialogUtils
    {
        public static void PlayAnims(this UIAnim[] anims)
        {
            foreach (var anim in anims)
            {
                anim.Play();
            }
        }
        
        public static void StopAnims(this UIAnim[] anims)
        {
            foreach (var anim in anims)
            {
                anim.Stop();
            }
        }
    }
}