using Galaga.Common.Utils;
using Galaga.Game.Constants;
using UnityEngine;
using UnityEngine.UI;


public class PlayAudioOnClick : MonoBehaviour
{
    private Button _btn;
    private AudioSource _audioSource;
    private void Awake()
    {
        _btn = gameObject.GetComponent<Button>();
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = SpawnUtils.Load<AudioClip>(ResourceConstants.Sounds+SoundConstants.Click);
        _btn.onClick.AddListener(OnBtnClicked);
    }

    private void OnBtnClicked()
    {
        _audioSource.Play();
    }

    private void OnDestroy()
    {
        _btn.onClick.RemoveListener(OnBtnClicked);
    }
}
