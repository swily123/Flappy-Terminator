using UnityEngine;

[RequireComponent(typeof(Animator))]

public class GunAnimator : MonoBehaviour
{
    private Animator _animtor;

    private void Awake()
    {
        _animtor = GetComponent<Animator>();
    }

    public void TrigerShootAnimator()
    {
        _animtor.SetTrigger(GunAnimatorData.Params.Shooted);
    }
}
