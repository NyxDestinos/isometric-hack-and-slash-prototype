using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;

    Character character;

    public void AttachCharacter(Character _character)
    {
        character = _character;
    }

    public void UpdateStatusBar()
    {
        healthBar.SetHealthBar(character.Health);
    }
}
