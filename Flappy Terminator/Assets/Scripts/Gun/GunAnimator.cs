using UnityEngine;

namespace Gun
{
    [RequireComponent(typeof(Animator))]

    public class GunAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void TriggerShootAnimator()
        {
            _animator.SetTrigger(GunAnimatorData.Params.Shooted);
        }
    }
}
