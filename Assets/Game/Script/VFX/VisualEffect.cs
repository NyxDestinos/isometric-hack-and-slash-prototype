using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Datas;

namespace Prototype.Objects
{
    public class VisualEffect : MonoBehaviour
    {
        private const float Y_AXIS_ANGLE = -45f;

        SpriteRenderer spriteRenderer;
        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void VisualEffectDirection(Vector3 target)
        {
            Vector3 adjustedDirection = Utility.IsometricInputAdjustment(target, Quaternion.Euler(0, Y_AXIS_ANGLE, 0));

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

