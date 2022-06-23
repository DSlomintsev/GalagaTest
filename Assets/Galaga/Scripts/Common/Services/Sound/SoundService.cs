using System;
using Cysharp.Threading.Tasks;
using Galaga.Common.Utils;
using Galaga.Game.Constants;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;


namespace Galaga.Common.Services.SoundPlayer
{
    public class SoundService:IInitializable,IDisposable, ISoundService
    {
        private ObjectPool<AudioSource> _audioClips = new (OnCreate);

        private static AudioSource OnCreate()
        {
            var go = new GameObject();
            return go.AddComponent<AudioSource>();
        }

        public void Initialize()
        {
        }

        public void Dispose()
        {
        }
        
        public void PlaySound(string soundId)
        {
            var audioClip = _audioClips.Get();
            var soundPath = ResourceConstants.Sounds + soundId;
            audioClip.clip = SpawnUtils.Load<AudioClip>(soundPath);
            audioClip.Play();

            ReleaseSound(audioClip);
        }

        private async UniTaskVoid ReleaseSound(AudioSource audioSource)
        {
            await UniTask.Delay((int)audioSource.clip.length*1000+10);
            _audioClips.Release(audioSource);
        }
        
        public void StopSound(string soundId)
        {
        }
    }
}