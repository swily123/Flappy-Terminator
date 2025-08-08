using UnityEngine;
using Spawners;

public class SpawnerBullets : Spawner<Bullet>
{
    public void SpawnBulletWithDirection(Vector3 direction)
    {
        Bullet bullet = GetObject();

        StartCoroutine(bullet.GoDirection(direction));
    }
}