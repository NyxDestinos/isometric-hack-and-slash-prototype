using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] protected AttackPointer attackPoint;
    [SerializeField] protected int attackDataIndex;
    [SerializeField] protected AttackData attackData;
    [SerializeField] protected Projectile projectile;

    [SerializeField] protected float attackCooldown = 0.25f;
    [SerializeField] protected float currentAttackCooldown;

    private void Update()
    {
        if (currentAttackCooldown > 0f)
        {
            currentAttackCooldown -= Time.deltaTime;
        }
    }

    public bool Attack()
    {
        if (currentAttackCooldown > 0f)
        {
            return false;
        }

        SetNextAttackData();
        CreateVisualEffect();

        attackPoint.AttackHitbox.Attack(currentAttack);

        return true;
    }

    public void Shoot()
    {
        CreateProjectile();
    }

    void SetNextAttackData()
    {
        attackDataIndex = attackData.GetNextAttackIndex(attackDataIndex);

        if (attackDataIndex == 0)
        {
            currentAttackCooldown = attackCooldown;
        }
    }

    void CreateVisualEffect()
    {
        GameObject gameObject = Instantiate(attackData.VisualEffect.gameObject, pointerPosition, attackData.VisualEffect.transform.rotation);
        VisualEffect visualEffect = gameObject.GetComponent<VisualEffect>();

        visualEffect.VisualEffectDirection(pointerForwardPosition);
    }

    void CreateProjectile()
    {
        GameObject gameObject = Instantiate(projectile.gameObject, pointerPosition, AttackPointer.transform.rotation);
        Projectile visualEffect = gameObject.GetComponent<Projectile>();
    }

    public int AttackDataIndex
    {
        get { return attackDataIndex; }
    }

    public bool IsOnAttackCooldown()
    {
        return currentAttackCooldown > 0f;
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
