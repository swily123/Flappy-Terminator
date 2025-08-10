using Units.Enemy;
using UnityEngine;

namespace Environment
{
    public class ExitZone : MonoBehaviour
    {
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out Enemy enemy))
            {
                enemy.Hit();
            }
        }
    }
}