using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public IEnumerator GoDirection(Vector3 direction)
    {
        transform.right = direction;

        while (enabled)
        {
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triger");
    }
}
