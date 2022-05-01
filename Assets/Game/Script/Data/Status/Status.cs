using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prototype.Characters;

namespace Prototype.Datas
{
    [System.Serializable]
    public class Status : ScriptableObject
    {
        public Color statusColor = Color.white;
        public bool isDurationOverride;
        public bool isStackOverride;

        public virtual Attack OnHit(Attack attack, StatusData status, List<StatusData> userStatusDataList, bool isPreview = false) { return attack; }

        public virtual Attack OnTakeDamage(Attack attack, Character attackCharacter, Character attackedCharacter, StatusData status, bool isCounter = false, bool isPenetrate = false) { return attack; }

        public virtual void OnAddStatus(StatusData thisStatus, Character ownerCharacter, StatusData applyStatusData) { }

        public virtual void OnSecondTick(Character character, StatusData status)
        {
            status.duration -= 1;

            if (character.GetComponent<Health>().isDead)
            {
                return;
            }

        }
    }
}

