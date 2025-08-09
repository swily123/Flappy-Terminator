using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IHittable
{
    [SerializeField] private EnemyZoner _enemyZoner;
    [SerializeField] private EnemyFireSystem _enemyFireSystem;
    [SerializeField] private EnemyMover _enemyMover;

    public event Action<Enemy> DespawnRequested;

    private void OnEnable()
    {
        _enemyZoner.PlayerEnteredZone += ActionsOnPlayerDiscovered;
    }

    private void OnDisable()
    {
        _enemyZoner.PlayerEnteredZone -= ActionsOnPlayerDiscovered;
    }

    public void Hit()
    {
        DespawnRequested?.Invoke(this);
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
}