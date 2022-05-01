using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField] private StatusBar statusBar;
    //private CapsuleCollider ;
    WaveManager waveManager;

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

    public override void TakeDamage(int damage, StatusData statusData)
    {
        base.TakeDamage(damage, statusData);

        statusBar.UpdateStatusBar();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        statusBar.UpdateStatusBar();
    }

    public override void Dead()
    {
        base.Dead();

        waveManager.RemoveDeadCharacter(this);
    }

    public void SetWaveManager(WaveManager _waveManager)
    {
        waveManager = _waveManager;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
