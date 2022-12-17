using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Animator anim;
    public int damage;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = Player.Instance.PlayerHealth;
    }

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
        _playerHealth.TakeDamage(damage);

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
