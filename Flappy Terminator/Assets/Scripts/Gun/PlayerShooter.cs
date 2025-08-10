using Spawners;
using UnityEngine;

namespace Gun
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private GunAnimator _gunAnimator;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private MouseTracker _mouseTracker;
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
            Vector3 bulletDirection = (_mouseTracker.MousePosition - _spawnerBullets.transform.position).normalized;
            bulletDirection.z = 0;

            if (Vector3.Angle(transform.right, bulletDirection) <= 100)
            {
                _spawnerBullets.SpawnBulletWithDirection(bulletDirection);
                _gunAnimator.TriggerShootAnimator();
            }
        }
    }
}
