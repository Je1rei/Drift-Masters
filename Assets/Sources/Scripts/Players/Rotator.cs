using System;
using DG.Tweening;
using UnityEngine;

namespace Players
{
    public class Rotator<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T _target;
        [SerializeField] private float _angle;
        [SerializeField] private float _duration;

        private Tween _tween;

        public T Target => _target;
        
        public void Construct()
        {
            Rotate();
        }

        private void OnDestroy()
        {
            _tween.Kill();
        }

        private void Rotate()
        {
            if (_target != null)
            {
                _tween = _target.transform.DORotate(new Vector3(0, _angle, 0), _duration, RotateMode.LocalAxisAdd)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Restart);
            }
        }
    }
}