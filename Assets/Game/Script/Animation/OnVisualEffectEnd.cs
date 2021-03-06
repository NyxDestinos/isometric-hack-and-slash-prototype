using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Animations
{
    public class OnVisualEffectEnd : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Destroy(animator.gameObject);
        }
    }
}

