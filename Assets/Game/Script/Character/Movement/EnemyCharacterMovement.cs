using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using Prototype.Behaviors;

namespace Prototype.Characters
{
    public class EnemyCharacterMovement : CharacterMovement
    {
        NavMeshAgent agent;
        EnemyBehavior behavior;

        protected override void Awake()
        {
            base.Awake();
            agent = GetComponent<NavMeshAgent>();
            behavior = GetComponent<EnemyBehavior>();

            agent.speed = moveSpeed;
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

            agent.enabled = true;
            characterAnimationController.OnCharacterMove(direction, isMoving);

            if (!isMoving)
            {
                agent.SetDestination(transform.position);
                characterStateMachine.SetIdleState();
                return;
            }

            characterAttack.ResetAttackIndex();
            agent.SetDestination(behavior.target.transform.position);
            characterStateMachine.SetMoveState();

        }
    }
}

