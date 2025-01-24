using System;
using UnityEngine;

namespace Services
{
    public class SettingsService : MonoBehaviour
    {
        [SerializeField] private Sprite[] _languageFlags;

        private readonly string[] _languages = { "ru", "en", "tr", "es" };
        
        public Sprite GetFlagForLanguage(string language)
        {
            int index = Array.IndexOf(_languages, language);
            
            if (index >= 0 && index < _languageFlags.Length)
            {
                return _languageFlags[index];
            }
            
            return null;
        }

        public string[] GetLanguages()
        {
            string[] languages = _languages;

            return languages;
        }
    }
}