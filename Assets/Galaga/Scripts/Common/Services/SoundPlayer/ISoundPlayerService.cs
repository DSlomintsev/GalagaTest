namespace Galaga.Common.Services.SoundPlayer
{
    public interface ISoundPlayerService
    {
        public void PlaySound(string soundId);
        public void StopSound(string soundId);
    }
}