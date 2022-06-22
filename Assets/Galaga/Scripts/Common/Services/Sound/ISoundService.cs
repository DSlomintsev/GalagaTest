namespace Galaga.Common.Services.SoundPlayer
{
    public interface ISoundService
    {
        public void PlaySound(string soundId);
        public void StopSound(string soundId);
    }
}