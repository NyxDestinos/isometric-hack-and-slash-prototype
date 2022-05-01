using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using Prototype.Characters;

namespace Prototype.Behaviors
{
    public class EnemyBehavior : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Character target;

        EnemyCharacterMovement characterMovement;
        // Start is called before the first frame update
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

        // Update is called once per frame
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

    }
}

