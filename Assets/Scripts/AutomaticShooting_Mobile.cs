using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShooting_Mobile : Shooting
{
    public Animator anim;
    public float rmp;
    public AudioSource shootSound;
    
    public UnityEvent onShoot;

    private float _interval;
    private float _lastShoot;

    private bool _isShooting;
    [SerializeField] private GunAmmo gunammo;

    private void Start()
    {
        _interval = 60 / rmp;
       // _lastShoot = 0;
    }
    
    public void StartShooting()
    {
        _isShooting = true;
    }

    public void StopShooting()
    {
        _isShooting = false;
    }

    private void Update()
    {
        if (_isShooting)
        {
            UpdateFiring();
        }

    }
    
    private void UpdateFiring()
    {
        if (Time.time - _lastShoot >= _interval)
        {
            Shoot();
            _lastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        if (gunammo.isReloading) return;
        anim.Play("Shoot", layer: -1, normalizedTime: 0);
        shootSound.Play();
        onShoot.Invoke();
    }

   
}
