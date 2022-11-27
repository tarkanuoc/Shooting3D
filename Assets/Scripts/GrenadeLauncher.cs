using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Shooting
{
    public GameObject bulletPrefab;
    public Transform firingPos;
    public Transform aimPos;
    public Animator launcherAnimator;
    public AudioSource shootingSound;
    public float bulletSpeed;

    [SerializeField] private GunAmmo gunammo;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (gunammo.LoadedAmo > 0)
                ShootBullet();
        }
    }

    public void PlayFireSound()
    {
        shootingSound.Play();
    }

    public void ShootBullet()
    {
        launcherAnimator.SetTrigger("Shoot");
        //     gunammo.SingleFireAmmoCounter();
    }

    public void AddProjectile()
    {
        if (gunammo.LoadedAmo > 0)
        {
            var bullet = Instantiate(bulletPrefab, firingPos.position, firingPos.rotation);
            bullet.transform.LookAt(aimPos);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed, ForceMode.Impulse);
        }

    }


}
