using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Vector3 IsometricInputAdjustment(Vector3 direction, Quaternion quaternion)
    {
        var isometricInputAdjustment = Matrix4x4.Rotate(quaternion);
        Vector3 adjustedDirection = isometricInputAdjustment.MultiplyPoint3x4(direction);

        return adjustedDirection;
    }

    public static bool IsTwoTransformInDistance(Transform object_A, Transform object_B, float dist)
    {
        return (object_A.position - object_B.position).sqrMagnitude < dist * dist;
    }
}
