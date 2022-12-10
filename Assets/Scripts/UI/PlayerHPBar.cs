using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth PlayerHealth;
    [SerializeField] private Image ImgHealthValue;

    public void UpdateHealthValue(int currentHealth, int maxHealth)
    {
        Debug.Log("======== current health = " + currentHealth);
        Debug.Log("========  max health = " + maxHealth);
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        float _ratio = (float)currentHealth / (float)maxHealth;
        ImgHealthValue.fillAmount = _ratio;
    }
}
