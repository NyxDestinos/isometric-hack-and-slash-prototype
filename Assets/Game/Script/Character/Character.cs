using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Health health;

    protected virtual void Awake()
    {
        health = GetComponent<Health>();
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

    public Health Health
    {
        get { return health; }
    }
}
