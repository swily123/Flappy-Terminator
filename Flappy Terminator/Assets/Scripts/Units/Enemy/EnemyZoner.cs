using System;
using Units.Player;
using UnityEngine;

namespace Units.Enemy
{
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
}
