using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attack
{
    public int damage;
    public float forwardForce;
    public float knockbackForce;

    public int Damage
    {
        get { return damage; }
    }
}
