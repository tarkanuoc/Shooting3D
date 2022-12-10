using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Animator anim;
    public int damage;
    public PlayerHealth playerHealth;

    public void StartAttack()
    {
        Debug.Log("=========== zombie attack");
        anim.SetBool("IsAttacking", true);
    }

    public void StopAttack()
    {
        anim.SetBool("IsAttacking", false);
    }

    public void OnAttack()
    {
        playerHealth.TakeDamage(damage);
    }
}
