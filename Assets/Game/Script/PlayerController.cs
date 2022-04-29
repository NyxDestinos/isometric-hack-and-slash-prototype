using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterMovement characterMovement;

    void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        GetPlayerMovement();
        GetPlayerAttack();
        GetPlayerDash();

    }

    private bool GetPlayerMovement()
    {
        

        if (GetPlayerDirection().magnitude <= 0.1f)
        {
            characterMovement.MoveCharacter(GetPlayerDirection());
            return false;
        }

        characterMovement.MoveCharacter(GetPlayerDirection(), true);

        return true;
    }

    private void GetPlayerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            characterMovement.Attack();
        }
    }

    public void GetPlayerDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterMovement.Dash(GetPlayerDirection(), true);
        }
    }

    private Vector3 GetPlayerDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        return direction;
    }


}
