using UnityEngine;

public class Enemy : MonoBehaviour, IHittable
{
    [SerializeField] private SpawnerBullets _spawnerBullets;

    public void Hit()
    {
        Destroy(gameObject);
    }
}