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

    public void OnAttack(int index)
    {
        playerHealth.TakeDamage(damage);

        switch (index)
        {
            case 0:
                Player.Instance.PlayerUI.ShowLeftScratch();
                break;
            case 1:
                Player.Instance.PlayerUI.ShowRightScratch();
                break;
            default:
                Player.Instance.PlayerUI.ShowLeftScratch();
                break;
        }
    }
}
