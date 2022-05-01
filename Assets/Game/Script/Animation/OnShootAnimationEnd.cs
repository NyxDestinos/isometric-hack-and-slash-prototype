using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Characters;

namespace Prototype.Animations
{
    public class OnShootAnimationEnd : StateMachineBehaviour
    {
        protected Character character;
        protected CharacterAnimationController characterAnimationController;
        protected CharacterStateMachine characterStateMachine;
        Animator animator;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Initialize(animator);

        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("isShooting", false);
            character.Shoot();
            characterStateMachine.SetIdleState();
        }

        void Initialize(Animator animator)
        {
            if (this.animator != null)
            {
                return;
            }

            this.animator = animator;
            characterAnimationController = animator.GetComponent<CharacterAnimationController>();
            character = characterAnimationController.Character;
            characterStateMachine = character.CharacterStateMachine;
        }
    }

}
