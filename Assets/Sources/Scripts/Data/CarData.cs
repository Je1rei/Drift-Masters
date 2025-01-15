using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Car", menuName = "ScriptableObjects/CarData", order = 3)]
    public class CarData : ScriptableObject
    {
        public int ID;
        public Car CarViewPrefab;
    }
}