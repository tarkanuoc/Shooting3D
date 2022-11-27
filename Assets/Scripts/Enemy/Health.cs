using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP;
    public Animator anim;

    private int HP;

    private bool isDead => HP <= 0;

    private void Start()
    {
        HP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        HP -= damage;
        if (isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("Die");
    }
}
