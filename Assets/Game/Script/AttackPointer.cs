using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointer : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    [SerializeField] private AttackHitbox attackHitbox;
    void Update()
    {
        InputRotationHandler();
    }

    void InputRotationHandler()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            pointer.position = transform.position + transform.forward;
        }
    }

    public Transform Pointer
    {
        get { return pointer; }
    }

    public AttackHitbox AttackHitbox
    {
        get { return attackHitbox; }
    }
}
