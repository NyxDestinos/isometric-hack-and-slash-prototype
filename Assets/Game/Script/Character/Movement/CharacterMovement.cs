using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Datas;

namespace Prototype.Characters
{
    public abstract class CharacterMovement : MonoBehaviour
    {

        [SerializeField] protected float moveSpeed = 4;
        [SerializeField] protected int dashSpeed = 10;
        [SerializeField] protected float dashTime = 0.5f;
        [SerializeField] protected float currentDashTime = 0f;
        [SerializeField] protected float dashCooldown = 0.1f;
        [SerializeField] protected float currentDashCooldown = 0f;

        [SerializeField] protected CharacterAnimationController characterAnimationController;
        protected CharacterAttack characterAttack;
        protected CharacterStateMachine stateMachine;
        protected Rigidbody characterRigidbody;

        private const float Y_AXIS_ANGLE = 45f;
        Vector3 dashDirection;

        protected virtual void Awake()
        {
            characterRigidbody = GetComponent<Rigidbody>();
            characterAttack = GetComponent<CharacterAttack>();
            stateMachine = GetComponent<CharacterStateMachine>();

        }

        protected virtual void Update()
        {
            UpdateDash();
        }

        public virtual void Attack()
        {
            if (!IsAbleToAttack())
            {
                return;
            }

            stateMachine.SetAttackState();
            characterAnimationController.OnCharacterAttack(true);
            MoveForce();
        }

        public virtual void Shoot()
        {
            if (!IsAbleToAttack())
            {
                return;
            }

            stateMachine.SetAttackState();
            characterAnimationController.OnCharacterShoot(true);
        }

        public void Dash(Vector3 direction, bool isMoving = false)
        {
            if (!IsAbleToDash())
            {
                return;
            }

            characterAttack.DashEffect();
            stateMachine.SetDashState();
            dashDirection = direction;
            characterAnimationController.OnCharacterDash(direction, true);
        }

        void UpdateDash()
        {

            if (IsDashing())
            {
                return;
            }

            if (IsDashFinish())
            {
                return;
            }

            if (currentDashCooldown >= 0f)
            {
                currentDashCooldown -= Time.deltaTime;
                return;
            }
        }

        
        private void MoveForce()
        {
            var direction = characterAttack.pointerForwardPosition;
            Attack attack = characterAttack.currentAttack;

            Vector3 adjustedDirection = Utility.IsometricInputAdjustment(direction, Quaternion.Euler(0, Y_AXIS_ANGLE, 0));
            adjustedDirection *= attack.ForwardForce;

            characterRigidbody.MovePosition(characterRigidbody.position + adjustedDirection * moveSpeed * Time.deltaTime);
        }

        public abstract void MoveCharacter(Vector3 direction, bool isMoving = false);

        protected abstract void Move(Vector3 direction);

        public float MoveSpeed
        {
            get
            {
                return moveSpeed;
            }
        }

        protected bool IsDashing()
        {
            if (stateMachine.IsDashState() && currentDashTime < dashTime)
            {
                Vector3 adjustedDirection = Utility.IsometricInputAdjustment(dashDirection, Quaternion.Euler(0, Y_AXIS_ANGLE, 0));

                characterRigidbody.MovePosition(characterRigidbody.position + adjustedDirection * dashSpeed * Time.deltaTime);

                characterAnimationController.OnCharacterDash(dashDirection, true);
                currentDashCooldown = 0f;
                currentDashTime += Time.deltaTime;
                return true;
            }

            characterAnimationController.OnCharacterDash(dashDirection, false);
            return false;
        }

        protected bool IsDashFinish()
        {
            if (stateMachine.IsDashState() && currentDashTime >= dashTime)
            {
                stateMachine.SetIdleState();
                currentDashTime = 0f;
                currentDashCooldown = dashCooldown;
                characterAnimationController.OnCharacterDash(dashDirection, false);
                return true;
            }

            return false;
        }

        protected bool IsAbleToAttack()
        {
            return !stateMachine.IsDashState() && !stateMachine.IsInterruptState() && !characterAttack.IsOnAttackCooldown();
        }

        protected bool IsAbleToDash()
        {
            return !stateMachine.IsDashState() && !stateMachine.IsInterruptState() && !(currentDashCooldown >= 0f);
        }

        protected bool IsAbleToMove()
        {
            return stateMachine.IsIdleState() || stateMachine.IsMoveState();
        }


    }
}


