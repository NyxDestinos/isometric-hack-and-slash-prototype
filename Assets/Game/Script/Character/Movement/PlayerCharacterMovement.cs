using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Characters
{
    public class PlayerCharacterMovement : CharacterMovement
    {
        public override void MoveCharacter(Vector3 direction, bool isMoving = false)
        {
            base.MoveCharacter(direction, isMoving);

            if (!IsMovable() || IsInterrupt())
            {
                return;
            }

            characterAnimationController.OnCharacterMove(direction, isMoving);

            if (!isMoving)
            {
                characterStateMachine.SetIdleState();
                return;
            }

            characterAttack.ResetAttackIndex();
            Move(direction);

            characterStateMachine.SetMoveState();
        }
    }
}

