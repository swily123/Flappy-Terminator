using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    private float _xOffset = 5f;
    private float _zOffset = -10;

    private void LateUpdate()
    {
        Vector3 birdPosition = new Vector3(_bird.transform.position.x + _xOffset, 0, _zOffset);
        transform.position = birdPosition;
    }
}
