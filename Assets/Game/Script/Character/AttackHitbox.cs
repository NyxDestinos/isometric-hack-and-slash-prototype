using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public Attack currentAttack;
    public GameObject owner;
    public List<EnemyCharacter> enemyCharacterList;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<EnemyCharacter>())
        {
            return;
        }

        EnemyCharacter enemy = other.GetComponent<EnemyCharacter>();

        enemyCharacterList.Add(enemy);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<EnemyCharacter>())
        {
            return;
        }

        EnemyCharacter enemy = other.GetComponent<EnemyCharacter>();

        enemyCharacterList.Remove(enemy);
    }

    public void Attack(Attack attack)
    {
        ClearNullEnemy();

        for (int i = 0; i < enemyCharacterList.Count; i++)
        {
            EnemyCharacter enemy = enemyCharacterList[i];

            enemy.TakeDamage(attack, owner);
        }
    }

    void ClearNullEnemy()
    {
        enemyCharacterList = enemyCharacterList.Where(x => x != null).ToList();
    }
}
