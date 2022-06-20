using SimpleMessageBus;

namespace Galaga.Common.Services.SoundPlayer
{
    public struct PlaySoundMessage : IMessage {
        public PlaySoundMessage(string soundId) {
            SoundId = soundId;
        }
    
        public string SoundId { get; private set; }
    }
}