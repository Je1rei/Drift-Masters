using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "DriftConfig", menuName = "ScriptableObjects/DriftConfig", order = 4)]
    public class DriftConfig : ScriptableObject
    {
        public float MoveSpeed;
        public float SteerAngle;
        public float Drag;
        public float Traction;
    }
}