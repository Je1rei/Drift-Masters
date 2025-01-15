using Data;
using UnityEngine;
using YG;

namespace Services
{
    public class CarService : MonoBehaviour
    {
        [SerializeField] private CarData[] _cars;

        private CarData _current;
        private int _id;

        public int ID => _id;
        public CarData Current => _current;

        public Car Load()
        {
            int index = YG2.saves.ChoisedCarID;
            
            if (index < 0 || index >= _cars.Length)
            {
                return null;
            }
            
            _current = _cars[index];
            _id = index;

            return _current.CarViewPrefab;
        }
    }
}