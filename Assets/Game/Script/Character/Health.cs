using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        
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
        StartCoroutine(StopKnock(0.2f));
    }

    private IEnumerator StopKnock(float timeWait)
    {
        yield return new WaitForSeconds(timeWait);
        rb.velocity = new Vector3();
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
