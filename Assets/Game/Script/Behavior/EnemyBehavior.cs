using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using Prototype.Characters;

namespace Prototype.Behaviors
{
    public class EnemyBehavior : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Character target;

        EnemyCharacterMovement characterMovement;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            characterMovement = GetComponent<EnemyCharacterMovement>();

            if (!GameObject.FindGameObjectWithTag("Player"))
            {
                return;
            }

            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        }

        void Update()
        {
            if (target == null)
            {
                characterMovement.MoveCharacter(transform.position, false);
                return;
            }

            characterMovement.MoveCharacter(target.transform.position - transform.position, true);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                characterMovement.Attack();
            }

        }

        public Character Target
        {
            get { return target; }
        }

        public Vector3 TargetPosition
        {
            get { return target.transform.position; }
        }

    }
}

