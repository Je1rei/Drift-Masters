using System.Collections.Generic;

namespace YG
{
    public partial class SavesYG
    {
        public float MusicVolume = 0.3f;
        public float SoundFxVolume = 0.3f;
        public int Coins = 30000;
        public int ChoisedCarID = 0;
        public List<int> OpenedLevels = new() { 0};
        public List<int> OpenedCars = new() { 0 };
    }
}