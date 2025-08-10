using System;
using System.Collections;
using UnityEngine;

namespace Gun
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public event Action<Bullet> DespawnRequested;
        private Coroutine _coroutine;

        public void GoDirection(Vector3 direction)
        {
            StopMoving();
            _coroutine = StartCoroutine(Moving(direction));
        }

        public void StopMoving()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }

        public void Collide()
        {
            DespawnRequested?.Invoke(this);
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
    }
}
