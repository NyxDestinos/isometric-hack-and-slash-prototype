using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    }

    // Update is called once per frame
    void Update()
    {
        characterMovement.MoveCharacter(target.transform.position - transform.position, true);
    }

}
