using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private float _speed;

    private Coroutine _coroutine;

    public void Move()
    {
        _coroutine = StartCoroutine(Moving());
    }

    public void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _animator.SetMovingAnimation(false);
    }

    private IEnumerator Moving()
    {
        _animator.SetMovingAnimation(true);

        while (enabled)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
            yield return null;
        }
    }
}
