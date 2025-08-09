using Spawners;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : Spawner<Enemy>
{
    [SerializeField] private float _spawnDelay;

    private Coroutine _coroutine;
    private List<Enemy> _activeEnemies = new List<Enemy>();

    public void StartSpawning()
    {
        _coroutine = StartCoroutine(Spawning());
    }

    public void StopSpawning()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    public void DisableAllActiveEnemies()
    {
        foreach (Enemy activeEnemy in _activeEnemies)
        {
            activeEnemy.DespawnRequested -= DespawnEnemy;
            ReleaseObject(activeEnemy);
        }

        _activeEnemies.Clear();
    }

    public void DisableAllActiveBulletsEnemies()
    {
        foreach (Enemy enemy in _activeEnemies)
        {
            enemy.DisableBullets();
        }
    }

    public void DespawnEnemy(Enemy enemy)
    {
        enemy.DespawnRequested -= DespawnEnemy;
        ReleaseObject(enemy);
        _activeEnemies.Remove(enemy);
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            yield return wait;
            Enemy enemy = GetObject();

            enemy.StartMoving();
            enemy.StopShooting();
            enemy.DespawnRequested += DespawnEnemy;
            _activeEnemies.Add(enemy);
        }
    }
}