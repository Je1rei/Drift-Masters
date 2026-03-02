using UnityEngine;
using YG;

namespace Services
{
    public class AudioService : MonoBehaviour
    {
        [SerializeField] private AudioSource _mainAudioSource;
        [SerializeField] private AudioSource _uiAudioSource;
        [SerializeField] private AudioSource _coinPickupSource;
        [SerializeField] private AudioSource _otherAudioSource;

        [SerializeField] private AudioClip[] _backgroundTracks;
        [SerializeField] private AudioClip _destroyedClip;

        private int _trackIndex = 0;

        private void Update()
        {
            if (_mainAudioSource.isPlaying == false && _backgroundTracks.Length > 0 && Time.timeScale != 0 &&
                YG2.isPauseGame == false)
            {
                PlayNextTrack();
            }
        }

        public void Construct()
        {
            SetMusicVolume(YG2.saves.MusicVolume);
            SetSFXVolume(YG2.saves.SoundFxVolume);

            _mainAudioSource.clip = _backgroundTracks[_trackIndex];
            _mainAudioSource.Play();
        }

        public void PlayUISound()
        {
            PlaySound(_uiAudioSource);
        }

        public void PlayOneShot()
        {
            PlaySound(_coinPickupSource);
        }

        public void PlayDestroyedSound()
        {
            PlaySound(_otherAudioSource, _destroyedClip);
        }

        public void SetMusicVolume(float value)
        {
            _mainAudioSource.volume = value;
            YG2.saves.MusicVolume = value;
        }

        public void SetSFXVolume(float value)
        {
            _uiAudioSource.volume = value;
            _coinPickupSource.volume = value;
            _otherAudioSource.volume = value;
            YG2.saves.SoundFxVolume = value;
        }

        private void PlayNextTrack()
        {
            _trackIndex = (_trackIndex + 1) % _backgroundTracks.Length;
            _mainAudioSource.clip = _backgroundTracks[_trackIndex];
            PlaySound(_mainAudioSource);
        }

        private void PlaySound(AudioSource source, AudioClip clip = null, bool isOneShot = false)
        {
            if (isOneShot && clip != null)
            {
                source.PlayOneShot(clip);
            }
            else
            {
                source.clip = clip ?? source.clip;
                source.Play();
            }
        }
    }
}