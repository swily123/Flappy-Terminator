using System;
using System.Collections;
using UnityEngine;

namespace Gun
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public event Action<Bullet> DespawnRequested;
        public event Action EnemyHitted;

        private Coroutine _coroutine;

        public void GoDirection(Vector3 direction)
        {
            _coroutine = StartCoroutine(Moving(direction));
        }

        public void StopMoving()
        {
            StopCoroutine(_coroutine);
        }

        private IEnumerator Moving(Vector3 direction)
        {
            transform.right = direction;

            while (enabled)
            {
                transform.Translate(Vector2.right * (Time.deltaTime * _speed));
                yield return null;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Barrier>(out _))
            {
                DespawnRequested?.Invoke(this);
            }
            else if (collision.TryGetComponent(out IHittable hittableObject))
            {
                if (collision.TryGetComponent<Enemy>(out _))
                {
                    EnemyHitted?.Invoke();
                }

                hittableObject.Hit();
                DespawnRequested?.Invoke(this);
            }
        }
    }
}
