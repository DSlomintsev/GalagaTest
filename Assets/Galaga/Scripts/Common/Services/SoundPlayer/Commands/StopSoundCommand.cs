using Zenject;

namespace Galaga.Common.Services.SoundPlayer.Commands
{
    public struct StopSoundSignal
    {
        public string SoundId { get; }

        public  StopSoundSignal(string soundId)
        {
            SoundId = soundId;
        }
    }

    public class  StopSoundCommand
    {
        [Inject] public ISoundPlayerService SoundPlayerService { get; set; }

        public void Execute(StopSoundSignal signal)
        {
            SoundPlayerService.StopSound(signal.SoundId);
        }
    }
}