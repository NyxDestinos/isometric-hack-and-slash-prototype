using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Prototype.Objects
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private Color32 popupColor = Color.white;
        public TextMeshPro popupText;

        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 1.5f);
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += new Vector3(0, 0.0003f);
        }

        public void SetDamageText(int Damage, float textSize = 3f, Color? fontColor = null)
        {
            popupText.text = Damage.ToString();

            popupText.color = fontColor ?? Color.white;
            popupText.fontSize = textSize;
        }
    }
}

