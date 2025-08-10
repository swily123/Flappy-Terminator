using System.Collections;
using UnityEngine;

namespace Units.Enemy
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _animator;
        [SerializeField] private float _speed;

        private Coroutine _coroutine;

        public void Move()
        {
            Stop();
            _animator.SetMovingAnimation(true);
            _coroutine = StartCoroutine(Moving());
        }

        public void Stop()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _animator.SetMovingAnimation(false);
            }
        }

        private IEnumerator Moving()
        {
            while (enabled)
            {
                transform.Translate(Vector3.left * (Time.deltaTime * _speed));
                yield return null;
            }
        }
    }
}
