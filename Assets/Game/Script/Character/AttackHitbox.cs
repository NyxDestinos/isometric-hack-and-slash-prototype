using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public enum TargetType
    {
        Player, Enemy
    }

    public TargetType targetType = TargetType.Player;
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

    public void Attack(Attack attack)
    {
        ClearNullEnemy();

        for (int i = 0; i < targetCharacterList.Count; i++)
        {
            Character target = targetCharacterList[i];

            target.TakeDamage(attack, owner);
        }
    }

    void ClearNullEnemy()
    {
        targetCharacterList = targetCharacterList.Where(x => x != null).ToList();
    }
}
