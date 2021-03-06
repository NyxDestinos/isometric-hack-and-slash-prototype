using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Animations
{
    public class OnAttackAnimationEnd : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (animator.GetBool("isNextAttacking"))
            {
                animator.SetBool("isNextAttacking", false);
                return;
            }

            animator.SetInteger("animationIndex", 0);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isShooting", false);
        }
    }
}

