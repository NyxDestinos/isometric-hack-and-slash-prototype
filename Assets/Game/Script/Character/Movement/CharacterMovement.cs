using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    [SerializeField] protected int moveSpeed = 4;
    [SerializeField] protected int dashSpeed = 10;
    [SerializeField] protected float dashTime = 0.5f;
    [SerializeField] protected float currentDashTime = 0f;
    [SerializeField] protected float dashCooldown = 0.1f;
    [SerializeField] protected float currentDashCooldown = 0f;

    [SerializeField] protected CharacterAnimationController characterAnimationController;
    protected CharacterAttack characterAttack;
    protected CharacterStateMachine characterStateMachine;
    protected Rigidbody characterRigidbody;

    Vector3 DashDirection;

    protected virtual void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        characterAttack = GetComponent<CharacterAttack>();
        characterStateMachine = GetComponent<CharacterStateMachine>();

    }

    protected virtual void Update()
    {
        
        OnDash();
    }

    public virtual void MoveCharacter(Vector3 direction, bool isMoving = false)
    {

    }

    public void Attack()
    {
        if (IsDash() || IsInterrupt() || characterAttack.IsOnAttackCooldown())
        {
            return;
        }

        characterStateMachine.SetAttackState();
        characterAnimationController.OnCharacterAttack(true);
        MoveForce();
    }

    public void Dash(Vector3 direction, bool isMoving = false)
    {
        if (IsDash() || !IsMovable() || IsInterrupt())
        {
            return;
        }

        characterStateMachine.SetDashState();
        DashDirection = direction;
        characterAnimationController.OnCharacterDash(direction, true);
    }

    public void OnDash()
    {

        if (IsDash() && currentDashTime < dashTime)
        {
            Vector3 adjustedDirection = Utility.IsometricInputAdjustment(DashDirection, Quaternion.Euler(0, 45, 0));

            characterRigidbody.MovePosition(characterRigidbody.position + adjustedDirection * dashSpeed * Time.deltaTime);

            characterAnimationController.OnCharacterDash(DashDirection, true);
            currentDashCooldown = 0f;
            currentDashTime += Time.deltaTime;
            return;
        }

        if (IsDash() && currentDashTime >= dashTime)
        {
            characterStateMachine.SetIdleState();
            currentDashTime = 0f;
            characterAnimationController.OnCharacterDash(DashDirection, false);
            return;
        }

        if (currentDashCooldown < dashCooldown)
        {
            currentDashCooldown += Time.deltaTime;
            return;
        }
        
    }

    protected void Move(Vector3 direction)
    {
        Vector3 adjustedDirection = Utility.IsometricInputAdjustment(direction, Quaternion.Euler(0, 45, 0));
        characterRigidbody.MovePosition(characterRigidbody.position + adjustedDirection * moveSpeed * Time.deltaTime);
    }

    private void MoveForce()
    {
        var direction = characterAttack.pointerForwardPosition;
        Attack attack = characterAttack.currentAttack;

        Vector3 adjustedDirection = Utility.IsometricInputAdjustment(direction, Quaternion.Euler(0, 45, 0));
        adjustedDirection *= attack.forwardForce;

        characterRigidbody.MovePosition(characterRigidbody.position + adjustedDirection * moveSpeed * Time.deltaTime);
    }



    public int MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
    }

    protected bool IsMovable()
    {
        return characterStateMachine.movementState == CharacterStateMachine.MovementState.Idle || characterStateMachine.movementState == CharacterStateMachine.MovementState.Move;
    }

    protected bool IsDash()
    {
        return characterStateMachine.movementState == CharacterStateMachine.MovementState.Dash;
    }

    protected bool IsInterrupt()
    {
        return characterStateMachine.movementState == CharacterStateMachine.MovementState.Interrupt;
    }

    
}
