using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHP;
    public Animator anim;
    public UnityEvent onDie;
    public NavMeshAgent agent;

    public EnemyHPBar enemyHPBar;

    private int _hp;

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
        enemyHPBar.UpdateHealthValue(_hp, maxHP);
        if (isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("Die");
        onDie.Invoke();
        agent.isStopped = true;
        enemyHPBar.HideHpBar();
       // agent.enabled = false;
    }
}
