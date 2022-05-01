using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Prototype.Characters;
using Prototype.Datas;

namespace Prototype.Objects
{
    public class AttackHitbox : MonoBehaviour
    {
        public enum TargetType
        {
            Player, Enemy
        }

        public TargetType targetType = TargetType.Enemy;
        public Attack currentAttack;
        public GameObject owner;
        public List<Character> targetCharacterList;
        private void OnTriggerEnter(Collider other)
        {
            Character target = null;

            switch (targetType)
            {
                case TargetType.Player:
                    target = other.GetComponent<PlayerCharacter>();
                    break;
                case TargetType.Enemy:
                    target = other.GetComponent<EnemyCharacter>();
                    break;
                default:
                    break;
            }


            if (target == null)
            {
                return;
            }

            targetCharacterList.Add(target);
        }

        private void OnTriggerExit(Collider other)
        {
            Character target = null;

            switch (targetType)
            {
                case TargetType.Player:
                    target = other.GetComponent<PlayerCharacter>();
                    break;
                case TargetType.Enemy:
                    target = other.GetComponent<EnemyCharacter>();
                    break;
                default:
                    break;
            }

            if (target == null)
            {
                return;
            }

            targetCharacterList.Remove(target);
        }

        public void Attack(Attack attack, Skill skill)
        {
            ClearNullEnemy();

            if (skill != null)
            {
                skill.ApplyOnAttackGlobal(owner.GetComponent<Character>(), targetType == TargetType.Enemy ? WaveManager.instance.enemyList : targetCharacterList);
                skill.ApplyOnAttack(owner.GetComponent<Character>(), targetCharacterList);
            }


            ApplyDamage(attack, skill);
            ApplyOnHit(attack, skill);
        }

        void ClearNullEnemy()
        {
            targetCharacterList = targetCharacterList.Where(x => x != null).ToList();
        }


        void ApplyDamage(Attack attack, Skill skill)
        {
            if (attack == null)
            {
                return;
            }

            for (int i = 0; i < targetCharacterList.Count; i++)
            {
                Character target = targetCharacterList[i];

                target.TakeDamage(attack, owner);
            }
        }
        void ApplyOnHit(Attack attack, Skill skill)
        {
            if (attack == null)
            {
                return;
            }

            if (skill == null)
            {
                return;
            }

            for (int i = 0; i < targetCharacterList.Count; i++)
            {
                Character target = targetCharacterList[i];

                skill.ApplyOnHit(target);
            }
        }
    }

}
