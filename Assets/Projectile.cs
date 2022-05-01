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
    [SerializeField] protected Skill skill;
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
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        Move();
    }

    public void AttachSkill(Skill _skill)
    {
        skill = _skill;
    }

    private void Move()
    {
        
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

        if (skill != null)
        {
            skill.ApplyOnHit(target);
            skill.ApplyOnProjectileHit(this, target);
            skill.ApplyOnProjectileHitGlobal(this, WaveManager.instance.enemyList);
        }
        
        Destroy(gameObject);
    }
}
