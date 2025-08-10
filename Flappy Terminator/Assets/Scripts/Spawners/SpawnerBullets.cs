using System.Collections.Generic;
using Gun;
using UnityEngine;

namespace Spawners
{
    public class SpawnerBullets : Spawner<Bullet>
    {
        private readonly List<Bullet> _activeBullets = new List<Bullet>();

        public void SpawnBulletWithDirection(Vector3 direction)
        {
            Bullet bullet = GetObject();
            bullet.DespawnRequested += DespawnBullet;
            bullet.GoDirection(direction);
            _activeBullets.Add(bullet);
        }

        public void DisableAllActiveBullets()
        {
            foreach (Bullet activeBullet in _activeBullets)
            {
                activeBullet.StopMoving();
                activeBullet.DespawnRequested -= DespawnBullet;
                ReleaseObject(activeBullet);
            }

            _activeBullets.Clear();
        }

        private void DespawnBullet(Bullet bullet)
        {
            bullet.StopMoving();
            bullet.DespawnRequested -= DespawnBullet;
            ReleaseObject(bullet);
            _activeBullets.Remove(bullet);
        }
    }
}