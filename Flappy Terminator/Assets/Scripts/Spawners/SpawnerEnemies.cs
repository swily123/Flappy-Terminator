using System;
using System.Collections;
using System.Collections.Generic;
using Units.Enemy;
using UnityEngine;

namespace Spawners
{
    public class SpawnerEnemies : Spawner<Enemy>
    {
        [SerializeField] private float _spawnDelay;

        public event Action EnemyHitted;
    
        private Coroutine _coroutine;
        private readonly List<Enemy> _activeEnemies = new List<Enemy>();

        public void StartSpawning()
        {
            StopSpawning();
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

        private void DespawnEnemy(Enemy enemy)
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
                enemy.DespawnRequested += DespawnEnemy;
                enemy.BulletCollided += HandlerHit;
                _activeEnemies.Add(enemy);
            }
        }

        private void HandlerHit(Enemy enemy)
        {
            EnemyHitted?.Invoke();
            enemy.BulletCollided -= HandlerHit;
        }
    }
}