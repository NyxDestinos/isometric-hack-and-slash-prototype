using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAttackAnimation : StateMachineBehaviour
{

    [SerializeField]protected Animator animator;
    protected CharacterAnimationController characterAnimationController;

    protected CharacterAttack characterAttack;
    protected CharacterMovement characterMovement;
    [SerializeField] protected int nextAnimationIndex;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Initialize(animator);
        characterMovement.IsMovable = false;

        characterAttack.Attack();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ChangeAnimation();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        characterMovement.IsMovable = true;
    }

    void Initialize(Animator animator)
    {
        if (this.animator != null)
        {
            return;
        }
        
        this.animator = animator;

        characterAnimationController = animator.GetComponent<CharacterAnimationController>();
        characterAttack = characterAnimationController.Character.GetComponent<CharacterAttack>();
        characterMovement = characterAnimationController.Character.GetComponent<CharacterMovement>();
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
