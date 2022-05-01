using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Datas;

namespace Prototype.Objects
{
    public class VisualEffect : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;
        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void VisualEffectDirection(Vector3 target)
        {
            Vector3 adjustedDirection = Utility.IsometricInputAdjustment(target, Quaternion.Euler(0, -45, 0));

            spriteRenderer.flipX = adjustedDirection.x < 0;
            spriteRenderer.flipY = adjustedDirection.z < 0;
        }

        public void SetVisualEffectColor(Skill skill)
        {
            if (skill == null)
            {
                return;
            }

            spriteRenderer.color = skill.skillColor;
        }
    }
}

