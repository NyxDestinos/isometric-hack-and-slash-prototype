using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Datas;

namespace Prototype.Characters
{
    public class CharacterSkill : MonoBehaviour
    {
        [SerializeField] private List<Skill> skillList = new List<Skill>();
        [SerializeField] private int attackSkillIndex = 0;
        [SerializeField] private int projectileSkillIndex = 0;
        [SerializeField] private int dashSkillIndex = 0;

        public void SwapAttackSkill()
        {
            attackSkillIndex += 1;
            attackSkillIndex %= skillList.Count;
        }

        public void SwapProjectileSkill()
        {
            projectileSkillIndex += 1;
            projectileSkillIndex %= skillList.Count;
        }

        public void SwapDashSkill()
        {
            dashSkillIndex += 1;
            dashSkillIndex %= skillList.Count;
        }

        public Skill AttackSkill
        {
            get 
            { 
                if (skillList.Count == 0)
                {
                    return null;
                }

                return skillList[attackSkillIndex]; 
            }
        }

        public Skill ProjectileSkill
        {
            get 
            {
                if (skillList.Count == 0)
                {
                    return null;
                }

                return skillList[projectileSkillIndex]; 
            }
        }

        public Skill DashSkill
        {
            get 
            {
                if (skillList.Count == 0)
                {
                    return null;
                }
                
                return skillList[dashSkillIndex]; 
            }
        }

    }
}

