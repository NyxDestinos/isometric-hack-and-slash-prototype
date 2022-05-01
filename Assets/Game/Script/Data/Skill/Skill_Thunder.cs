using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Prototype.Characters;
using Prototype.Objects;

namespace Prototype.Datas
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Skill_Thunder", menuName = "ScriptableObject/Skill/Thunder")]
    public class Skill_Thunder : Skill
    {
        public int damage;
        public int targetCount;
        public float areaOfEffect;
        public VisualEffect visualEffect;

        public override void ApplyOnAttackGlobal(Character attacker, List<Character> targetList)
        {
            targetList = targetList.Where(x => (attacker.transform.position - x.transform.position).sqrMagnitude < areaOfEffect * areaOfEffect).ToList();

            if (targetList.Count == 0)
            {
                return;
            }

            for (int i = 0; i < targetCount; i++)
            {
                Character target = targetList[Random.Range(0, targetList.Count - 1)];
                Transform targetSprite = target.animationController.transform;
                Vector3 spawnPosition = new Vector3(targetSprite.transform.position.x, visualEffect.transform.position.y, targetSprite.transform.position.z);
                VisualEffect _visualEffect = Instantiate(visualEffect.gameObject, spawnPosition, visualEffect.transform.rotation).GetComponent<VisualEffect>();
                target.TakeDamage(damage);
            }
        }

        public override void ApplyOnProjectileHitGlobal(Projectile projectile, List<Character> targetList)
        {
            targetList = targetList.Where(x => (projectile.transform.position - x.transform.position).sqrMagnitude < areaOfEffect * areaOfEffect).ToList();

            if (targetList.Count == 0)
            {
                return;
            }

            for (int i = 0; i < targetCount; i++)
            {
                Character target = targetList[Random.Range(0, targetList.Count - 1)];
                Transform targetSprite = target.animationController.transform;
                Vector3 spawnPosition = new Vector3(targetSprite.transform.position.x, visualEffect.transform.position.y, targetSprite.transform.position.z);
                VisualEffect _visualEffect = Instantiate(visualEffect.gameObject, spawnPosition, visualEffect.transform.rotation).GetComponent<VisualEffect>();
                target.TakeDamage(damage);
            }
        }

        public override void ApplyOnDash(Character attacker, float dashAreaOfEffect)
        {
            base.ApplyOnDash(attacker, dashAreaOfEffect);
            var targetList = WaveManager.instance.enemyList.Where(x => (attacker.transform.position - x.transform.position).sqrMagnitude < dashAreaOfEffect * dashAreaOfEffect).ToList();

            if (targetList.Count == 0)
            {
                return;
            }

            for (int i = 0; i < targetCount; i++)
            {
                Character target = targetList[Random.Range(0, targetList.Count - 1)];
                Transform targetSprite = target.animationController.transform;
                Vector3 spawnPosition = new Vector3(targetSprite.transform.position.x, visualEffect.transform.position.y, targetSprite.transform.position.z);
                VisualEffect _visualEffect = Instantiate(visualEffect.gameObject, spawnPosition, visualEffect.transform.rotation).GetComponent<VisualEffect>();
                target.TakeDamage(damage);
            }

        }
    }
}


