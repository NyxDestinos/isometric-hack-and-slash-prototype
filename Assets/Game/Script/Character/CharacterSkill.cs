using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Datas;

namespace Prototype.Characters
{
    public class CharacterSkill : MonoBehaviour
    {
        [SerializeField] private Skill attackSkill;
        [SerializeField] private Skill projectileSkill;
        [SerializeField] private Skill dashSkill;

        public Skill AttackSkill
        {
            get { return attackSkill; }
        }

        public Skill ProjectileSkill
        {
            get { return projectileSkill; }
        }

        public Skill DashSkill
        {
            get { return dashSkill; }
        }
    }
}

