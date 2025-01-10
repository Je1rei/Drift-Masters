using UnityEngine;

namespace Services
{
    public class AudioService : MonoBehaviour
    {
        [SerializeField] private AudioSource _mainAudioSource;

        private AudioSource _uiAudioSource;

        public void Init(AudioSource uiAudioSource)
        {
            _uiAudioSource = uiAudioSource;
            //SetVolume(YG2.saves.Volume);
        }

        public void PlaySound()
        {
            _uiAudioSource.Play();
        }

        public void SetVolume(float value)
        {
            AudioListener.volume = value;
            //YG2.saves.Volume = value;
        }
    }
}