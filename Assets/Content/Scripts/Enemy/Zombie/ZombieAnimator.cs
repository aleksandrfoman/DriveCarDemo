using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Content.Scripts.Enemy.Zombie
{
    [Serializable]
    public class ZombieAnimator
    {
        public bool IsAttackComplete => isAttackComplete;
        
        [SerializeField] private Animator animator;
        [SerializeField] private AnimationEventsListener animListener;
        private bool isAttackComplete;
        
        private static readonly int s_idleId = Animator.StringToHash("IdleId");
        private static readonly int s_idleTrigger = Animator.StringToHash("IdleTrigger");
        private static readonly int s_moveTrigger = Animator.StringToHash("MoveTrigger");
        private static readonly int s_attackTrigger = Animator.StringToHash("AttackTrigger");

        public void Init()
        {
            animListener.OnAttack += AttackComplete;
        }
        public void PlayIdle()
        {
            int rnd = Random.Range(0, 3);
            animator.SetInteger(s_idleId,rnd);
            animator.SetTrigger(s_idleTrigger);
        }
        
        public void PlayMove()
        {
            animator.SetTrigger(s_moveTrigger);
        }
        
        public void PlayAttack()
        {
            animator.SetTrigger(s_attackTrigger);
            DOTween.To(() => animator.GetLayerWeight(1), x => animator.SetLayerWeight(1, x), 1f, 0.05f);
        }

        public void AttackComplete()
        {
            isAttackComplete = true;
        }
    }
}
