using UnityEngine;

public class Bird : MonoBehaviour, IHittable
{
    public void Hit()
    {
        Time.timeScale = 0;
        Debug.Log("Game Over");
    }
}