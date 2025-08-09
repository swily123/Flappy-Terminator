using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMovingAnimation(bool value)
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsMoving, value);
    }

    public void TriggerShoot()
    {
        _animator.SetTrigger(EnemyAnimatorData.Params.Shoot);
    }
}