using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField] private StatusBar statusBar;

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
}
