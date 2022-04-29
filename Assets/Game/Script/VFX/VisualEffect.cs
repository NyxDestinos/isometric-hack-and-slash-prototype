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
        Vector3 adjustedDirection = Utility.IsometricInputAdjustment(target, Quaternion.Euler(0, -45, 0));

        spriteRenderer.flipX = adjustedDirection.x < 0;
        spriteRenderer.flipY = adjustedDirection.z < 0;
    }
}
