using UnityEngine;
using Spawners;
using System;

public class SpawnerBullets : Spawner<Bullet>
{
    public event Action EnemyHittedr;

    public void SpawnBulletWithDirection(Vector3 direction)
    {
        Bullet bullet = GetObject();
        bullet.DespawnRequested += DespawnBullet;
        bullet.EnemyHitted += HandlerHit;
        bullet.GoDirection(direction);
    }

    public void DespawnBullet(Bullet bullet)
    {
        bullet.StopMoving();
        bullet.DespawnRequested -= DespawnBullet;
        bullet.EnemyHitted -= HandlerHit;
        ReleaseObject(bullet);
    }

    private void HandlerHit()
    {
        EnemyHittedr?.Invoke();
    }
}