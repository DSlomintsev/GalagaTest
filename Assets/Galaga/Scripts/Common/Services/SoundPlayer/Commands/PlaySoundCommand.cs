using Zenject;

namespace Galaga.Common.Services.SoundPlayer.Commands
{
    public struct PlaySoundSignal
    {
        public string SoundId { get; }

        public  PlaySoundSignal(string soundId)
        {
            SoundId = soundId;
        }
    }

    public class  PlaySoundCommand
    {
        [Inject] public ISoundPlayerService SoundPlayerService { get; set; }

        public void Execute(PlaySoundSignal signal)
        {
            SoundPlayerService.PlaySound(signal.SoundId);
        }
    }
}