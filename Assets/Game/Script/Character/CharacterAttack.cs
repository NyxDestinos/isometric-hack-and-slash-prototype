using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] protected AttackPointer attackPoint;
    [SerializeField] protected int attackDataIndex;
    [SerializeField] protected AttackData attackData;

    public void Attack()
    {
        SetNextAttackData();
        CreateVisualEffect();

        attackPoint.AttackHitbox.Attack(currentAttack);
    }

    void SetNextAttackData()
    {
        attackDataIndex = attackData.GetNextAttackIndex(attackDataIndex);
    }

    void CreateVisualEffect()
    {
        GameObject gameObject = Instantiate(attackData.VisualEffect.gameObject, pointerPosition, attackData.VisualEffect.transform.rotation);
        VisualEffect visualEffect = gameObject.GetComponent<VisualEffect>();

        visualEffect.VisualEffectDirection(pointerForwardPosition);
    }

    public int AttackDataIndex
    {
        get { return attackDataIndex; }
    }

    public void ResetAttackIndex()
    {
        attackDataIndex = 0;
    }

    public Attack currentAttack
    {
        get { return attackData.GetAttack(AttackDataIndex); }
    }

    public AttackPointer AttackPointer
    {
        get { return attackPoint; }
    }

    public Vector3 pointerPosition
    {
        get { return attackPoint.Pointer.position; }
    }

    public Vector3 pointerForwardPosition
    {
        get { return attackPoint.transform.forward; }
    }
}
