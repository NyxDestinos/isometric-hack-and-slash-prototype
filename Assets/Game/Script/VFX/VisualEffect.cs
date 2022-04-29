using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffect : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void VisualEffectDirection(Vector3 target)
    {
        var isometricInputAdjustment = Matrix4x4.Rotate(Quaternion.Euler(0, -45, 0));
        Vector3 adjustedDirection = isometricInputAdjustment.MultiplyPoint3x4(target);

        spriteRenderer.flipX = adjustedDirection.x < 0;
        spriteRenderer.flipY = adjustedDirection.z < 0;
    }
}
