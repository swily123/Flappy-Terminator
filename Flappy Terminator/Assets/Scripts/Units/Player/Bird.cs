using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bird : MonoBehaviour, IHittable
{
    [SerializeField] private GameInstruction _game;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Hit()
    {
        _game.GameOver();
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Platform>(out _))
        {
            _game.GameOver();
        }
    }
}