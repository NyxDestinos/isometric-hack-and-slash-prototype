using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Characters
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] SpriteRenderer healthBar;

        Vector3 healthbarLocalScale;

        private void Awake()
        {
            healthbarLocalScale = healthBar.transform.localScale;
        }

        public void SetHealthBar(Health _health)
        {
            if (_health == null)
                return;

            Vector3 newLocalScale = new Vector3(((float)_health.CurrentHealth / (float)_health.MaxHealth) * healthbarLocalScale.x, healthbarLocalScale.y, healthbarLocalScale.z);
            healthBar.transform.localScale = newLocalScale;
        }
    }
}

