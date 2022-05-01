using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Health health;
    protected StatusContainer statusContainer;
    public CharacterAnimationController animationController;

    protected virtual void Awake()
    {
        health = GetComponent<Health>();
        statusContainer = GetComponent<StatusContainer>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }

    public virtual void TakeDamage(Attack attack, GameObject attacker)
    {
        health.TakeDamage(attack, attacker);
    }

    public virtual void TakeDamage(int damage, StatusData statusData)
    {
        health.TakeDamage(damage, statusData);
    }

    public virtual void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }

    public virtual void ApplyStatus(StatusData statusData)
    {
        statusContainer.ApplyStatusData(statusData);
    }

    public virtual void Dead()
    {
        
    }

    public Health Health
    {
        get { return health; }
    }
}
