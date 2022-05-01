using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Objects
{
    public class AttackPointer : MonoBehaviour
    {
        [SerializeField] protected Transform pointer;
        [SerializeField] protected AttackHitbox attackHitbox;
        void Update()
        {
            InputRotationHandler();
        }

        protected virtual void InputRotationHandler()
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
}

