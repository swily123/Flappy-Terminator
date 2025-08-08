using UnityEngine;
using Spawners;

public class SpawnerBullets : Spawner<Bullet>
{
    public void SpawnBulletWithDirection(Vector3 direction)
    {
        Bullet bullet = GetObject();
        bullet.GoDirection(direction);
        bullet.DespawnRequested += DespawnBullet;
    }

    public void DespawnBullet(Bullet bullet)
    {
        bullet.StopMoving();
        bullet.DespawnRequested -= DespawnBullet;
        ReleaseObject(bullet);
    }
}