using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Datas;
using Prototype.Objects;

namespace Prototype.Characters
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth;

        [SerializeField] private float currentKnockbackCooldown;
        [SerializeField] private float knockbackCooldown;

        [SerializeField] private float currentImmuneDuration;
        [SerializeField] private float ImmuneDuration;

        bool isKnock = false;
        Character character;
        CharacterStateMachine characterStateMachine;
        [SerializeField]CharacterAnimationController characterAnimationController;
        Rigidbody rb;

        [SerializeField] Popup popup;

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            character = GetComponent<Character>();
            characterStateMachine = GetComponent<CharacterStateMachine>();
            characterAnimationController = character.CharacterAnimationController;
        }


        void Update()
        {
            UpdateKnockback();
            UpdateImmune();
        }

        public void TakeDamage(Attack attack, GameObject attacker)
        {
            if (characterStateMachine.IsDashState() || IsImmune())
            {
                return;
            }

            CreatePopupDamage(attack.Damage);
            CalculateDamage(attack.Damage);
            Knockback(attack, attacker);
        }

        public virtual void TakeDamage(int damage, StatusData statusData)
        {
            CreatePopupDamage(damage, 2f, statusData.Status.statusColor);
            CalculateDamage(damage);
        }

        public virtual void TakeDamage(int damage)
        {
            CreatePopupDamage(damage, 2f);
            CalculateDamage(damage);
        }

        void CalculateDamage(int damage)
        {
            CurrentHealth -= damage;

            if (isDead)
            {
                character.Dead();
                Destroy(gameObject);
            }
        }

        void CreatePopupDamage(int damage, float textSize = 3, Color? fontColor = null)
        {
            float randomXSpawnpoint = Random.Range(-0.3f, 0.3f);
            float randomYSpawnpoint = Random.Range(-0.3f, 0.3f);
            float zSpawnPoint = 0.1f;
            Vector3 randomPositionThreshold = new Vector3(randomXSpawnpoint, randomYSpawnpoint, zSpawnPoint);

            GameObject dmgPop = Instantiate(popup.gameObject, transform.position + randomPositionThreshold, popup.transform.rotation);
            dmgPop.GetComponent<Popup>().SetDamageText(damage, textSize, fontColor);
        }

        void Knockback(Attack attack, GameObject attacker)
        {
            Vector3 difference = gameObject.transform.position - attacker.transform.position;
            Vector3 finalDiff = difference.normalized * attack.KnockbackForce * rb.mass;
            rb.AddForce(finalDiff, ForceMode.Impulse);

            characterStateMachine.SetInterruptState();
            characterAnimationController.OnCharacterInterrupt(difference, true);
            currentImmuneDuration = ImmuneDuration;
            currentKnockbackCooldown = knockbackCooldown;
            isKnock = true;
        }

        void UpdateKnockback()
        {
            if (currentKnockbackCooldown >= 0f && isKnock)
            {
                currentKnockbackCooldown -= Time.deltaTime;
                return;
            }

            if (currentKnockbackCooldown < 0f && isKnock)
            {
                isKnock = false;

                characterStateMachine.SetIdleState();
                characterAnimationController.OnCharacterInterrupt(new Vector3(), false);
            }

            rb.velocity = new Vector3();
        }

        void UpdateImmune()
        {
            if (IsImmune())
            {
                currentImmuneDuration -= Time.deltaTime;
                return;
            }
        }

        bool IsImmune()
        {
            return currentImmuneDuration > 0f;
        }

        public bool isDead
        {
            get { return currentHealth == 0; }
        }

        public int CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = Mathf.Max(value, 0); }
        }

        public int MaxHealth
        {
            get { return maxHealth; }
        }
    }
}

