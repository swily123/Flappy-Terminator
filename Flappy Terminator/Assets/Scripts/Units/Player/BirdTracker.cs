using UnityEngine;

namespace Units.Player
{
    public class BirdTracker : MonoBehaviour
    {
        [SerializeField] private Bird _bird;

        private const float XOffset = 5f;
        private const float ZOffset = -10;

        private void LateUpdate()
        {
            Vector3 birdPosition = new Vector3(_bird.transform.position.x + XOffset, 0, ZOffset);
            transform.position = birdPosition;
        }
    }
}
