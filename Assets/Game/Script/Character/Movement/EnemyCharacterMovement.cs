using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCharacterMovement : CharacterMovement
{
    NavMeshAgent agent;
    EnemyBehavior behavior;

    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        behavior = GetComponent<EnemyBehavior>();
    }

    public override void MoveCharacter(Vector3 direction, bool isMoving = false)
    {
        base.MoveCharacter(direction, isMoving);

        if (!IsMovable() || IsInterrupt())
        {
            characterAnimationController.OnCharacterMove(direction, false);
            agent.enabled = false;
            return;
        }

        characterAnimationController.OnCharacterMove(direction, isMoving);

        if (!isMoving)
        {
            characterStateMachine.SetIdleState();
            return;
        }

        characterAttack.ResetAttackIndex();
        agent.enabled = true;
        agent.SetDestination(behavior.target.transform.position);
        characterStateMachine.SetMoveState();

    }
}
