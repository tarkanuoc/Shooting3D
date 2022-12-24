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

    private bool _isShoot = false;

    [SerializeField] private GunAmmo gunammo;

    private void Start()
    {
        IsLocked = true;
    }

    private void OnEnable()
    {
       // IsLocked = true;
    }

    private void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    if (gunammo.LoadedAmo > 0)
        //        ShootBullet();
        //}

        if (!IsLocked && _isShoot)
        {
            _isShoot = false;
            IsLocked = true;
            ShootBullet();
        }
    }

    public void StartShooting()
    {
        enabled = true;
        IsLocked = false;
        _isShoot = true;
    }

    public void PlayFireSound()
    {
        shootingSound.Play();
    }

    public void ShootBullet()
    {
        if (gunammo.isReloading) return;
        Debug.Log("======= shoot bullet");
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
