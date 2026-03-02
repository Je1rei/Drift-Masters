using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "DriftConfig", menuName = "ScriptableObjects/DriftConfig", order = 4)]
    public class DriftConfig : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float SteerAngle { get; private set; }
        [field: SerializeField] public float Drag { get; private set; }
        [field: SerializeField] public float Traction { get; private set; }
    }
}