using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Attack Data", menuName = "ScriptableObject/AttackData/Attack")]
public class AttackData : ScriptableObject
{
    [SerializeField] private List<Attack> attackList = new List<Attack>();
    [SerializeField] private VisualEffect visualEffect;

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
        int nextAttackIndex = (index + 1) % attackList.Count;

        return nextAttackIndex;
    }

    public VisualEffect VisualEffect
    {
        get { return visualEffect; }
    }
}
