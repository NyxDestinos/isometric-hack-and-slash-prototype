using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Datas
{
    [System.Serializable]
    public class Attack
    {
        [SerializeField] private int damage;
        [SerializeField] private float forwardForce;
        [SerializeField] private float knockbackForce;

        public int Damage
        {
            get { return damage; }
        }

        public float ForwardForce
        {
            get { return forwardForce; }
        }

        public float KnockbackForce
        {
            get { return knockbackForce; }
        }

    }
}

