using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Prototype.Objects
{
    public class Popup : MonoBehaviour
    {
        public TextMeshPro popupText;
        [SerializeField] private Color32 popupColor = Color.white;
        [SerializeField] private float floatUpSpeed = 0.003f;
        [SerializeField] private float timeBeforeDestroy = 1.5f;

        void Start()
        {
            Destroy(gameObject, timeBeforeDestroy);
        }

        void Update()
        {
            transform.position += new Vector3(0, floatUpSpeed);
        }

        public void SetDamageText(int Damage, float textSize = 3f, Color? fontColor = null)
        {
            popupText.text = Damage.ToString();

            popupText.color = fontColor ?? Color.white;
            popupText.fontSize = textSize;
        }
    }
}

