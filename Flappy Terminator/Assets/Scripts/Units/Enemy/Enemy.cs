using System;
using Gun;
using Units.Player;
using UnityEngine;

namespace Units.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyZoner _enemyZoner;
        [SerializeField] private EnemyFireSystem _enemyFireSystem;
        [SerializeField] private EnemyMover _enemyMover;

        public event Action<Enemy> DespawnRequested;
        public event Action<Enemy> BulletCollided;
    
        private void OnEnable()
        {
            _enemyZoner.PlayerEnteredZone += ActionsOnPlayerDiscovered;
        }

        private void OnDisable()
        {
            _enemyZoner.PlayerEnteredZone -= ActionsOnPlayerDiscovered;
        }

        public void StartMoving()
        {
            _enemyMover.Move();
        }

        public void StopShooting()
        {
            _enemyFireSystem.Stop();
        }

        public void DisableBullets()
        {
            _enemyFireSystem.ClearBullets();
        }

        public void Hit()
        {
            DespawnRequested?.Invoke(this);
        }
        
        private void ActionsOnPlayerDiscovered(Bird bird)
        {
            StartShooting(bird);
            StopMoving();
        }

        private void StartShooting(Bird bird)
        {
            _enemyFireSystem.Shoot(bird);
        }

        private void StopMoving()
        {
            _enemyMover.Stop();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out Bullet bullet))
            {
                BulletCollided?.Invoke(this);
                bullet.Collide();
                Hit();
            }
        }
    }
}