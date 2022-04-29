using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    public enum MovementState
    {
        Idle, Move, Attack, Dash, Interrupt
    }

    public MovementState movementState;

    public void SetIdleState()
    {
        movementState = MovementState.Idle;
    }

    public void SetMoveState()
    {
        movementState = MovementState.Move;
    }

    public void SetAttackState()
    {
        movementState = MovementState.Attack;
    }

    public void SetDashState()
    {
        movementState = MovementState.Dash;
    }

    public void SetInterruptState()
    {
        movementState = MovementState.Interrupt;
    }
}
