using System.Collections.Generic;

namespace YG
{
    public partial class SavesYG
    {
        public float MusicVolume = 0.3f;
        public float SoundFxVolume = 0.3f;
        public int Coins = 0;
        public List<int> OpenedLevels = new();
        public List<int> OpenedCars = new();

        public void Init()
        {
            OpenedLevels.Add(0);
            OpenedCars.Add(0);
        }
    }
}