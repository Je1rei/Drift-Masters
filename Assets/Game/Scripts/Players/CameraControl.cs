using UnityEngine;

namespace Players
{
    public class CameraControl : MonoBehaviour
    {
        [SerializeField] private Player _target;

        [SerializeField] private float _followSpeed = 10f;
        [SerializeField] private Vector3 _offset = new Vector3(1, 0f, -26);

        private float _fixedYPosition;

        private void Awake()
        {
            _fixedYPosition = transform.position.y;
        }

        private void LateUpdate()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            Vector3 targetPosition = new Vector3(
                _target.transform.position.x + _offset.x,
                _fixedYPosition,
                _target.transform.position.z + _offset.z
            );

            transform.position = Vector3.Lerp(transform.position, targetPosition, _followSpeed * Time.deltaTime);
        }
    }
}