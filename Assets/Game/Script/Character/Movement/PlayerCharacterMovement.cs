using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Characters
{
    public class PlayerCharacterMovement : CharacterMovement
    {
        private const float Y_AXIS_ANGLE = 45f;

        public override void MoveCharacter(Vector3 direction, bool isMoving = false)
        {
            if (!IsAbleToMove())
            {
                return;
            }

            characterAnimationController.OnCharacterMove(direction, isMoving);

            if (!isMoving)
            {
                stateMachine.SetIdleState();
                return;
            }
            
            Move(direction);
        }

        protected override void Move(Vector3 direction)
        {
            Vector3 adjustedDirection = Utility.IsometricInputAdjustment(direction, Quaternion.Euler(0, Y_AXIS_ANGLE, 0));
            characterRigidbody.MovePosition(characterRigidbody.position + adjustedDirection * moveSpeed * Time.deltaTime);

            characterAttack.ResetAttackIndex();
            stateMachine.SetMoveState();
        }
    }
}

