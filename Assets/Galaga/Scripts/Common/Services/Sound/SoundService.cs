using System;
using UnityEngine;
using Zenject;

namespace Galaga.Common.Services.SoundPlayer
{
    public class SoundService:IInitializable,IDisposable, ISoundService
    {
        public void PlaySound(string soundId)
        {
            Debug.Log("PLAY SOUND="+soundId);
        }
        
        public void StopSound(string soundId)
        {
            Debug.Log("STOP SOUND="+soundId);
        }

        public void Initialize()
        {
        }

        public void Dispose()
        {
        }
    }
}