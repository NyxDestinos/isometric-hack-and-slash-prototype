using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Characters;

namespace Prototype.Datas
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Status_Burn", menuName = "ScriptableObject/Status/Burn")]
    public class Status_Burn : Status
    {
        public override void OnSecondTick(Character character, StatusData statusData)
        {
            base.OnSecondTick(character, statusData);
            if (character.GetComponent<Health>().isDead)
            {
                return;
            }

            character.TakeDamage(statusData.StackAmount, statusData);
        }
    }
}

