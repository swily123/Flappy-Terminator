using System.Collections;
using UnityEngine;

namespace Units.Player
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class BirdMover : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;

        private const float Speed = 2.5f;
        private const float JumpForce = 5;
        private const float JumpRotation = 30;
        private const float MinRotation = -45;
        private const float SpeedRotation = 1;
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
            _rigidbody.velocity = new Vector2(Speed, JumpForce);
            transform.rotation = Quaternion.Euler(0, 0, JumpRotation);
        }

        private IEnumerator Diving()
        {
            Quaternion rotation = Quaternion.Euler(0, 0, MinRotation);

            while (enabled)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, SpeedRotation * Time.deltaTime);
                yield return null;
            }
        }
    }
}
