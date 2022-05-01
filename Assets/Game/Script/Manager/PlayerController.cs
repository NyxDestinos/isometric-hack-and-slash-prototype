using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Characters;
using System;

namespace Prototype
{
    public class PlayerController : MonoBehaviour
    {
        CharacterMovement characterMovement;
        CharacterSkill characterSkill;

        void Awake()
        {
            characterMovement = GetComponent<CharacterMovement>();
            characterSkill = GetComponent<CharacterSkill>();

        }

        void Update()
        {
            GetPlayerMovement();
            GetPlayerAttack();
            GetPlayerDash();
            GetPlayerSwapSkill();

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

            if (Input.GetMouseButtonDown(1))
            {
                characterMovement.Shoot();
            }
        }

        private void GetPlayerDash()
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


        private void GetPlayerSwapSkill()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                characterSkill.SwapAttackSkill();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                characterSkill.SwapProjectileSkill();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                characterSkill.SwapDashSkill();
            }
        }

    }
}

