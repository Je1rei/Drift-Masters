using UnityEngine;
using UnityEngine.Audio;
using YG;

namespace Services
{
    public class AudioService : MonoBehaviour
    {
        [SerializeField] private AudioSource _mainAudioSource;
        [SerializeField] private AudioSource _uiAudioSource;
        
        public void Construct()
        {
            _mainAudioSource.Play();
            SetMusicVolume(YG2.saves.MusicVolume);
            SetSFXVolume(YG2.saves.SoundFxVolume);
        }

        public void PlaySound()
        {
            _uiAudioSource.Play();
        }

        public void SetMusicVolume(float value) // дубляж
        {
            _mainAudioSource.volume = value;
            YG2.saves.MusicVolume = value;
        }        
        
        public void SetSFXVolume(float value) // дубляж
        {
            _uiAudioSource.volume = value;
            YG2.saves.SoundFxVolume = value;
        }
    }
}