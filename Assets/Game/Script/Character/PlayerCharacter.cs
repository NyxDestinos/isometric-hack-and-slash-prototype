using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.UI;

namespace Prototype.Characters
{
    public class PlayerCharacter : Character
    {
        protected override void Start()
        {

        }

        protected override void Update()
        {

        }

        public override void Dead()
        {
            PlayerUI.instance.GameOver();
        }
    }
}

