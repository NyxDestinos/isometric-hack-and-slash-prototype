using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New AttackData", menuName = "ScriptableObject/AttackData/Attack")]
public class AttackData : ScriptableObject
{
    [SerializeField] List<Attack> attackList = new List<Attack>();
    [SerializeField] VisualEffect visualEffect;

    public Attack GetAttack(int index)
    {
        if (index >= attackList.Count)
        {
            return null;
        }

        return attackList[index];
    }

    public int GetNextAttackIndex(int index)
    {
        int attackDataIndex = (index + 1) % attackList.Count;

        return attackDataIndex;
    }

    public VisualEffect VisualEffect
    {
        get { return visualEffect; }
    }
}
