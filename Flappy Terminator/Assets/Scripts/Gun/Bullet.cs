using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Action<Bullet> DespawnRequested;

    private Coroutine _coroutine;

    public void GoDirection(Vector3 direction)
    {
        _coroutine = StartCoroutine(Moving(direction));
    }

    public void StopMoving()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Moving(Vector3 direction)
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
        if (collision.TryGetComponent<Barrier>(out _))
        {
            DespawnRequested?.Invoke(this);
        }
        else if(collision is IHittable hittableObject)
        {
            Debug.Log("hit");
            hittableObject.Hit();
            DespawnRequested?.Invoke(this);
        }
    }
}
