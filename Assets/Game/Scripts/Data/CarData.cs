using Players;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Car", menuName = "ScriptableObjects/CarData", order = 3)]
    public class CarData : ScriptableObject
    {
        [field: SerializeField] public int ID { get; private set; }
        [field: SerializeField] public Car CarViewPrefab { get; private set; }
        [field: SerializeField] public DriftConfig DriftConfig { get; private set; }
    }
}