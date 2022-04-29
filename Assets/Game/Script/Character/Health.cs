using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;

    private float currentKnockbackCooldown;
    [SerializeField] private float knockbackCooldown;

    bool isKnock = false;
    Character character;
    CharacterStateMachine characterStateMachine;
    CharacterAnimationController characterAnimationController;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        character = GetComponent<Character>();
        characterStateMachine = GetComponent<CharacterStateMachine>();
        characterAnimationController = character.animationController;
    }


    void Update()
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

    public void TakeDamage(Attack attack, GameObject attacker)
    {
        CurrentHealth -= attack.Damage;
        Knockback(attack, attacker);

        if (isDead)
        {
            Destroy(gameObject);
        }
    }

    public void Knockback(Attack attack, GameObject attacker)
    {
        Vector3 difference = gameObject.transform.position - attacker.transform.position;
        Vector3 finalDiff = difference.normalized * attack.knockbackForce * rb.mass;
        rb.AddForce(finalDiff, ForceMode.Impulse);

        characterStateMachine.SetInterruptState();
        characterAnimationController.OnCharacterInterrupt(difference, true);
        currentKnockbackCooldown = knockbackCooldown;
        isKnock = true;
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
