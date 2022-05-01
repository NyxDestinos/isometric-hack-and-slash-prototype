using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Skill_Fire", menuName = "ScriptableObject/Skill/Fire")]
public class Skill_Fire : Skill
{
    [SerializeField] Status status;
    [SerializeField] int baseDuration = 3;
    [SerializeField] int baseStack = 3;
    
    public override void ApplyOnHit(Character target)
    {
        StatusData statusData = new StatusData(status, baseDuration, baseStack);
        target.ApplyStatus(statusData);
    }

    public override void ApplyOnDash(Character attacker, float dashAreaOfEffect)
    {
        base.ApplyOnDash(attacker, dashAreaOfEffect);

        var targetList = WaveManager.instance.enemyList.Where(x => (attacker.transform.position - x.transform.position).sqrMagnitude < dashAreaOfEffect * dashAreaOfEffect).ToList();

        if (targetList.Count == 0)
        {
            return;
        }

        for (int i = 0; i < targetList.Count; i++)
        {
            Character target = targetList[Random.Range(0, targetList.Count - 1)];

            StatusData statusData = new StatusData(status, baseDuration, baseStack);
            target.ApplyStatus(statusData);
        }
    }
}
