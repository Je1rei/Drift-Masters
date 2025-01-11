using System;
using UnityEngine;

namespace Services
{
    public class SettingsService : MonoBehaviour
    {
        [SerializeField] private Sprite[] _languageFlags;

        private readonly string[] _languages = { "ru", "en", "tr", "es" };
        private AudioService _audioService;

        public void Construct(AudioService audioService)
        {
            _audioService = audioService;
        }

        public Sprite GetFlagForLanguage(string language)
        {
            int index = Array.IndexOf(_languages, language);
            
            if (index >= 0 && index < _languageFlags.Length)
            {
                return _languageFlags[index];
            }

            Debug.LogError($"Флаг для языка {language} не найден!");
            
            return null;
        }

        public string[] GetLanguages()
        {
            string[] languages = _languages;

            return languages;
        }
    }
}