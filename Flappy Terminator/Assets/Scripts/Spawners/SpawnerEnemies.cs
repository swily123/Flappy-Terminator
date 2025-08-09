using Spawners;
using System.Collections;
using UnityEngine;

public class SpawnerEnemies : Spawner<Enemy>
{
    [SerializeField] private float _spawnDelay;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            Enemy enemy = GetObject();

            enemy.StartMoving();
            enemy.StopShooting();
            enemy.DespawnRequested += DespawnEnemy;
            yield return wait;
        }
    }

    public void DespawnEnemy(Enemy enemy)
    {
        enemy.DespawnRequested -= DespawnEnemy;
        ReleaseObject(enemy);
    }
}