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
        [Inject] public ISoundService SoundService { get; set; }

        public void Execute(StopSoundSignal signal)
        {
            SoundService.StopSound(signal.SoundId);
        }
    }
}