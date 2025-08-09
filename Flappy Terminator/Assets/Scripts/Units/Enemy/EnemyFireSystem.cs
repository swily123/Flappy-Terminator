using System.Collections;
using UnityEngine;

public class EnemyFireSystem : MonoBehaviour
{
    [SerializeField] private SpawnerBullets _spawnerBullets;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private float _shhotDelay;

    private Coroutine _coroutine;

    public void Shoot(Bird bird)
    {
        _coroutine = StartCoroutine(Shooting(bird));
    }

    public void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    public void ClearBullets()
    {
        _spawnerBullets.DisableAllActiveBullets();
    }

    private IEnumerator Shooting(Bird target)
    {
        WaitForSeconds wait = new WaitForSeconds(_shhotDelay);

        while (enabled)
        {
            _animator.TriggerShoot();
            Vector3 bulletDirection = (target.transform.position - _spawnerBullets.transform.position).normalized;
            bulletDirection.z = 0;
            _spawnerBullets.SpawnBulletWithDirection(bulletDirection);

            yield return wait;
        }
    }
}
