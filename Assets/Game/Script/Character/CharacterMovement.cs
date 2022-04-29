using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    [SerializeField] private int moveSpeed = 4;
    [SerializeField] private int dashSpeed = 10;
    [SerializeField] private float dashTime = 0.5f;
    [SerializeField] private float currentDashTime = 0f;
    [SerializeField] private float dashCooldown = 0.1f;
    [SerializeField] private float currentDashCooldown = 0f;

    [SerializeField] CharacterAnimationController characterAnimationController;
    CharacterAttack characterAttack;
    CharacterStateMachine characterStateMachine;
    Rigidbody characterRigidbody;

    Vector3 DashDirection;

    private void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        characterAttack = GetComponent<CharacterAttack>();
        characterStateMachine = GetComponent<CharacterStateMachine>();


    }

    private void Update()
    {
        OnDash();
    }

    public void MoveCharacter(Vector3 direction, bool isMoving = false)
    {
        if (!IsMovable())
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

    public void Attack()
    {
        if (IsDash())
        {
            return;
        }

        characterStateMachine.SetAttackState();
        characterAnimationController.OnCharacterAttack(true);
        MoveForce();
    }

    public void Dash(Vector3 direction, bool isMoving = false)
    {
        if (IsDash() || !IsMovable())
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
            var isometricInputAdjustment = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
            Vector3 adjustedDirection = isometricInputAdjustment.MultiplyPoint3x4(DashDirection);

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

    private void Move(Vector3 direction)
    {
        var isometricInputAdjustment = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        Vector3 adjustedDirection = isometricInputAdjustment.MultiplyPoint3x4(direction);

        characterRigidbody.MovePosition(characterRigidbody.position + adjustedDirection * moveSpeed * Time.deltaTime);
    }

    private void MoveForce()
    {
        var direction = characterAttack.pointerForwardPosition;
        Attack attack = characterAttack.currentAttack;
        var isometricInputAdjustment = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        Vector3 adjustedDirection = isometricInputAdjustment.MultiplyPoint3x4(direction);
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

    private bool IsMovable()
    {
        return characterStateMachine.movementState == CharacterStateMachine.MovementState.Idle || characterStateMachine.movementState == CharacterStateMachine.MovementState.Move;
    }

    private bool IsDash()
    {
        return characterStateMachine.movementState == CharacterStateMachine.MovementState.Dash;
    }

    
}
