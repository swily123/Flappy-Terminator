using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BirdMover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private float _speed = 2.5f;
    private float _jumpForce = 5;
    private float _jumpRotation = 30;
    private float _minRotation = -45;
    private float _speedRotation = 1;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Diving());
    }

    private void OnEnable()
    {
        _inputReader.JumpButtonPressed += Jump;
    }

    private void OnDisable()
    {
        _inputReader.JumpButtonPressed -= Jump;
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_speed, _jumpForce);
        transform.rotation = Quaternion.Euler(0, 0, _jumpRotation);
    }

    private IEnumerator Diving()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, _minRotation);

        while (enabled)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speedRotation * Time.deltaTime);
            yield return null;
        }
    }
}
