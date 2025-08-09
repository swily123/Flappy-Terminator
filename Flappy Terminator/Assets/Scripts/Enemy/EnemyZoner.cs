using System;
using UnityEngine;

public class EnemyZoner : MonoBehaviour
{
    public event Action<Bird> PlayerEnteredZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bird bird))
        {
            PlayerEnteredZone?.Invoke(bird);
        }
    }
}
