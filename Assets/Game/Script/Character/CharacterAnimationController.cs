using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    Character character;
    SpriteRenderer spriteRenderer;
    Animator animator;

    CharacterAttack characterAttack;



    void Start()
    {
        character = transform.parent.GetComponent<Character>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        characterAttack = character.GetComponent<CharacterAttack>();
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

    public void OnCharacterDash(Vector3 direction, bool isDash = false)
    {
        SpriteMoveDirection(direction, isDash);

        animator.SetBool("isDash", isDash);
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
        var isometricInputAdjustment = Matrix4x4.Rotate(Quaternion.Euler(0, -45, 0));
        Vector3 adjustedDirection = isometricInputAdjustment.MultiplyPoint3x4(target);

        spriteRenderer.flipX = adjustedDirection.x < 0;
    }

    public Character Character
    {
        get { return character; }
    }
}
