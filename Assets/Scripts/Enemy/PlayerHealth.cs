using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP;
    public UnityEvent onDie;
    
    [SerializeField]private int _hp;
    
    private bool isDead => _hp <= 0;

    public int Hp { get => _hp; set => _hp = value; }

    private void Start()
    {
        _hp = maxHP;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        _hp -= damage;
        if (isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("============ Player Die");
      //  Time.timeScale = 0;
        onDie.Invoke();
    }
}
