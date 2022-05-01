using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Characters
{
    public class CharacterAnimationController : MonoBehaviour
    {
        Character character;
        SpriteRenderer spriteRenderer;
        Animator animator;

        private const float Y_AXIS_ANGLE = -45f;

        CharacterAttack characterAttack;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        void Start()
        {
            character = transform.parent.GetComponent<Character>();
            characterAttack = character.CharacterAttack;
        }

        public void OnCharacterMove(Vector3 direction, bool isMoving = false)
        {
            SpriteMoveDirection(direction, isMoving);

            animator.SetBool("isMoving", isMoving);
        }

        public void OnCharacterAttack(bool isAttacking = false)
        {
            SpriteAttackDirection(characterAttack.pointerForwardPosition);
            if (animator.GetBool("isAttacking"))
            {
                animator.SetBool("isNextAttacking", isAttacking);
                return;
            }

            animator.SetBool("isAttacking", isAttacking);
        }

        public void OnCharacterShoot(bool isAttacking = false)
        {
            SpriteAttackDirection(characterAttack.pointerForwardPosition);
            if (animator.GetBool("isShooting"))
            {
                return;
            }

            animator.SetBool("isShooting", isAttacking);
        }

        public void OnCharacterDash(Vector3 direction, bool isDash = false)
        {
            SpriteMoveDirection(direction, isDash);

            animator.SetBool("isDash", isDash);
        }

        public void OnCharacterInterrupt(Vector3 direction, bool isInterrupt = false)
        {
            SpriteMoveDirection(direction);

            animator.SetBool("isInterrupt", isInterrupt);
        }

        private void SpriteMoveDirection(Vector3 direction, bool isMoving = false)
        {
            if (!isMoving)
            {
                return;
            }
            spriteRenderer.flipX = direction.x < 0;
        }

        
        private void SpriteAttackDirection(Vector3 target)
        {
            Vector3 adjustedDirection = Utility.IsometricInputAdjustment(target, Quaternion.Euler(0, Y_AXIS_ANGLE, 0));

            spriteRenderer.flipX = adjustedDirection.x < 0;
        }

        public Character Character
        {
            get { return character; }
        }
    }
}


