using UnityEngine;

namespace Units.Enemy
{
    public static class EnemyAnimatorData
    {
        public static class Params
        {
            public static readonly int Shoot = Animator.StringToHash(nameof(Shoot));
            public static readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
        }
    }
}
