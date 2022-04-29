using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPointer : AttackPointer
{
    [SerializeField] private EnemyCharacter owner;
    protected override void InputRotationHandler()
    {
        var _owner = owner.GetComponent<EnemyBehavior>();
        if (!_owner.GetComponent<EnemyBehavior>())
        {
            return;
        }

        if (_owner.GetComponent<EnemyBehavior>().target == null)
        {
            return;
        }
        var _target = _owner.target.transform;
        transform.LookAt(new Vector3(_target.position.x, transform.position.y, _target.position.z));
        pointer.position = transform.position + transform.forward;

    }
}
