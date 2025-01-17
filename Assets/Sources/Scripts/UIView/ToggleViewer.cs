using UnityEngine;
using UnityEngine.Serialization;

namespace UIView
{
    public class ToggleViewer : MonoBehaviour
    {
        [SerializeField] private TargetView _target;

        public void Deactivate()
        {
            _target.gameObject.SetActive(false);
        }
    }
}