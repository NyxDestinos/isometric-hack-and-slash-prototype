using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Characters;

namespace Prototype.Animations
{
    public class UpdateAttackAnimation : StateMachineBehaviour
    {

        protected Animator animator;
        protected CharacterAnimationController characterAnimationController;

        protected Character character;
        protected CharacterMovement characterMovement;
        protected CharacterStateMachine characterStateMachine;
        [SerializeField] protected int nextAnimationIndex;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Initialize(animator);

            character.Attack();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            characterStateMachine.SetAttackState();
            ChangeAnimation();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!animator.GetBool("isNextAttacking"))
            {
                characterStateMachine.SetIdleState();
                return;
            }

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
            characterMovement = character.CharacterMovement;
            characterStateMachine = character.CharacterStateMachine;
        }

        void ChangeAnimation()
        {
            if (animator == null)
            {
                return;
            }

            SetNextAttackIndex();
        }

        void SetNextAttackIndex()
        {
            if (!animator.GetBool("isNextAttacking"))
            {
                return;
            }

            animator.SetInteger("animationIndex", nextAnimationIndex);
        }
    }
}


