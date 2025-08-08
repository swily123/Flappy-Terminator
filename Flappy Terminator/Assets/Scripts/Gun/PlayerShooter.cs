using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GunAnimator _gunAnimator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private SpawnerBullets _spawnerBullets;

    private void OnEnable()
    {
        _inputReader.LeftButtonClicked += Shoot;
    }

    private void OnDisable()
    {
        _inputReader.LeftButtonClicked -= Shoot;
    }

    private void Shoot()
    { 
        Vector3 bulletDirection = (_inputReader.MousePosition - _spawnerBullets.transform.position).normalized;
        bulletDirection.z = 0;

        _spawnerBullets.SpawnBulletWithDirection(bulletDirection);
        _gunAnimator.TrigerShootAnimator();
    }
}
