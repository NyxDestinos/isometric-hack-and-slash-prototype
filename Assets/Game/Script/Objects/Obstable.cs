using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Objects
{
    public class Obstable : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Projectile")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

