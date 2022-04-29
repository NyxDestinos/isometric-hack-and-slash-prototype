using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public enum TargetType
    {
        Player, Enemy
    }

    [SerializeField] protected Attack attack;
    public TargetType targetType = TargetType.Enemy;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float lifeTime = 5f;

    [SerializeField] Transform visual;
    Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        body.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        StartCoroutine(OutOfLifetime());
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        
    }

    IEnumerator OutOfLifetime()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Character target = null;

        Debug.Log(collision.gameObject.tag);

        switch (targetType)
        {
            case TargetType.Player:
                target = collision.gameObject.GetComponent<PlayerCharacter>();
                break;
            case TargetType.Enemy:
                target = collision.gameObject.GetComponent<EnemyCharacter>();
                break;
            default:
                break;
        }


        if (target == null)
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            return;
        }

        target.TakeDamage(attack, gameObject);
        Destroy(gameObject);
    }
}
