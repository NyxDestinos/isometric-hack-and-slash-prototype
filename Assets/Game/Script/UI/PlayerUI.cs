using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Prototype.Characters;
using UnityEngine.SceneManagement;

namespace Prototype.UI
{
    public class PlayerUI : MonoBehaviour
    {
        public static PlayerUI instance { get; private set; }
        [SerializeField] private Character character;
        private Health health;
        private CharacterSkill characterSkill;

        [SerializeField] private Image healthBar;
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI attackSkillText;
        [SerializeField] private TextMeshProUGUI projectileSkillText;
        [SerializeField] private TextMeshProUGUI dashSkillText;

        [SerializeField] private GameObject gameOverUI;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

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
                SetDeadUnitUI();
                return;
            }

            healthBar.fillAmount = (float)health.CurrentHealth / (float)health.MaxHealth;
            healthText.text = $"{health.CurrentHealth}/{health.MaxHealth}";

            attackSkillText.text = $"Weapon\n{characterSkill.AttackSkill.skillName}";
            projectileSkillText.text = $"Projectile\n{characterSkill.ProjectileSkill.skillName}";
            dashSkillText.text = $"Dash\n{characterSkill.DashSkill.skillName}";
        }

        public void GameOver()
        {
            gameOverUI.SetActive(true);
        }

        public void SetDeadUnitUI()
        {
            healthBar.fillAmount = 0f;
            healthText.text = $"Dead";
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }


    }
}

