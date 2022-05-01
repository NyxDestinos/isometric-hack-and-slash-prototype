using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Datas;

namespace Prototype.Characters
{
    [RequireComponent(typeof (Rigidbody))]
    [RequireComponent(typeof (Collider))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(CharacterAttack))]
    [RequireComponent(typeof(CharacterStateMachine))]
    [RequireComponent(typeof(CharacterMovement))]
    public abstract class Character : MonoBehaviour
    {
        protected Health health;
        protected CharacterAttack characterAttack;
        protected StatusContainer statusContainer;
        protected CharacterStateMachine stateMachine;
        protected CharacterMovement characterMovement;
        [SerializeField] protected CharacterAnimationController animationController;

        protected virtual void Awake()
        {
            health = GetComponent<Health>();
            characterAttack = GetComponent<CharacterAttack>();
            statusContainer = GetComponent<StatusContainer>();
            stateMachine = GetComponent<CharacterStateMachine>();
            characterMovement = GetComponent<CharacterMovement>();
        }

        protected abstract void Start();

        protected abstract void Update();

        public virtual void Attack()
        {
            characterAttack.Attack();
        }

        public virtual void Shoot()
        {
            characterAttack.Shoot();
        }

        public virtual void TakeDamage(Attack attack, GameObject attacker)
        {
            health.TakeDamage(attack, attacker);
        }

        public virtual void TakeDamage(int damage, StatusData statusData)
        {
            health.TakeDamage(damage, statusData);
        }

        public virtual void TakeDamage(int damage)
        {
            health.TakeDamage(damage);
        }

        public virtual void ApplyStatus(StatusData statusData)
        {
            statusContainer.ApplyStatusData(statusData);
        }

        public abstract void Dead();

        public CharacterAttack CharacterAttack
        {
            get { return characterAttack; }
        }

        public Health Health
        {
            get { return health; }
        }

        public CharacterAnimationController CharacterAnimationController
        {
            get { return animationController; }
        }

        public Transform SpriteTransform
        {
            get { return animationController.transform; }
        }

        public CharacterStateMachine CharacterStateMachine
        {
            get { return stateMachine; }
        }

        public CharacterMovement CharacterMovement
        {
            get { return characterMovement; }
        }
    }
}

