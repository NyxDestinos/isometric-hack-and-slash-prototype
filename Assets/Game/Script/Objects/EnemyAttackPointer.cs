using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Characters;
using Prototype.Behaviors;

namespace Prototype.Objects
{
    public class EnemyAttackPointer : AttackPointer
    {
        [SerializeField] private EnemyCharacter owner;

        EnemyBehavior behavior;

        private void Start()
        {
            behavior = owner.GetComponent<EnemyBehavior>();
        }

        protected override void InputRotationHandler()
        {

            if (!behavior)
            {
                return;
            }

            if (!behavior.Target)
            {
                return;
            }

            LookAtTarget(behavior.TargetPosition);

        }
    }
}

