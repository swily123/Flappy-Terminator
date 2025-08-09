using UnityEngine;

public class ExitZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Enemy enemy))
        {
            enemy.Hit();
        }
    }
}