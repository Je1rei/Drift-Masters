using System.Collections.Generic;
using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public float MusicVolume = 0.3f;
        public float SoundFxVolume = 0.3f;
        public int Coins = 0;
        public int ChoisedCarID = 0;
        public HashSet<int> OpenedLevels = new();
        public HashSet<int> OpenedCars = new();
        
        public void Init()
        {
            OpenedLevels.Add(0);
            OpenedCars.Add(0);
            OpenedCars.Add(1);
            OpenedCars.Add(2);
            OpenedCars.Add(3);
            
            Debug.Log(OpenedCars.Count);
        }
    }
}