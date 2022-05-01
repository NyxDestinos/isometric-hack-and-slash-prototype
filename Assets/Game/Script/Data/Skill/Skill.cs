using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Characters;
using Prototype.Objects;

namespace Prototype.Datas
{
    public class Skill : ScriptableObject
    {
        [SerializeField] public string skillName;
        [SerializeField] public Color skillColor = Color.white;
        public virtual void ApplyOnHit(Character target)
        {

        }

        public virtual void ApplyOnAttack(Character attacker, List<Character> targetList)
        {

        }

        public virtual void ApplyOnAttackGlobal(Character attacker, List<Character> targetList)
        {

        }

        public virtual void ApplyOnProjectileHit(Projectile projectile, Character character)
        {

        }

        public virtual void ApplyOnProjectileHitGlobal(Projectile projectile, List<Character> targetList)
        {

        }

        public virtual void ApplyOnDash(Character attacker, float dashAreaOfEffect)
        {

        }
    }
}

