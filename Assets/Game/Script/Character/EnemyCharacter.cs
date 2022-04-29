using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField] private StatusBar statusBar;
    //private CapsuleCollider ;


    protected override void Start()
    {
        base.Start();
        statusBar.AttachCharacter(this);
    }

    public override void TakeDamage(Attack attack, GameObject attacker)
    {
        base.TakeDamage(attack, attacker);

        statusBar.UpdateStatusBar();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
