using Spawners;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBullets : Spawner<Bullet>
{
    public event Action EnemyHitted;

    private List<Bullet> _activeBullets = new List<Bullet>();

    public void SpawnBulletWithDirection(Vector3 direction)
    {
        Bullet bullet = GetObject();
        bullet.DespawnRequested += DespawnBullet;
        bullet.EnemyHitted += HandlerHit;
        bullet.GoDirection(direction);
        _activeBullets.Add(bullet);
    }

    public void DisableAllActiveBullets()
    {
        foreach (Bullet activeBullet in _activeBullets)
        {
            activeBullet.StopMoving();
            activeBullet.DespawnRequested -= DespawnBullet;
            activeBullet.EnemyHitted -= HandlerHit;
            ReleaseObject(activeBullet);
        }

        _activeBullets.Clear();
    }

    private void DespawnBullet(Bullet bullet)
    {
        bullet.StopMoving();
        bullet.DespawnRequested -= DespawnBullet;
        bullet.EnemyHitted -= HandlerHit;
        ReleaseObject(bullet);
        _activeBullets.Remove(bullet);
    }

    private void HandlerHit()
    {
        EnemyHitted?.Invoke();
    }
}