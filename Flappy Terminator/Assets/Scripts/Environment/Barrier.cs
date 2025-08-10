using Gun;
using UnityEngine;

namespace Environment
{
    public class Barrier : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out Bullet bullet))
            {
                bullet.Collide();
            }
        }
    }
}