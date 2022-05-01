using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Animations
{
    public class OnDashAnimation : StateMachineBehaviour
    {
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isNextAttacking", false);
        }

    }
}

