using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    [SerializeField] private Health Health;
    [SerializeField] private Image ImgHealthValue;
    [SerializeField] private GameObject HpBar;

    public void UpdateHealthValue(int currentHealth, int maxHealth)
    {
        Debug.Log("======== current health = " + currentHealth);
        Debug.Log("========  max health = " + maxHealth);
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        float _ratio = (float)currentHealth / (float)maxHealth;
        ImgHealthValue.fillAmount = _ratio;
    }

    public void HideHpBar()
    {
        HpBar.SetActive(false);
    }

}
