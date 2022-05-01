using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Character character;
    private Health health;
    private CharacterSkill characterSkill;

    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI attackSkillText;
    [SerializeField] private TextMeshProUGUI projectileSkillText;
    [SerializeField] private TextMeshProUGUI dashSkillText;

    void Start()
    {
        health = character.GetComponent<Health>();
        characterSkill = character.GetComponent<CharacterSkill>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if (character == null)
        {
            return;
        }

        healthBar.fillAmount = (float)health.CurrentHealth / (float)health.MaxHealth;
        healthText.text = health.CurrentHealth + "/" + health.MaxHealth;

        attackSkillText.text = "Weapon\n" + characterSkill.attackSkill.skillName;
        projectileSkillText.text = "Projectile\n" + characterSkill.projectileSkill.skillName;
        dashSkillText.text = "Dash\n" + characterSkill.dashSkill.skillName;
    }


}
