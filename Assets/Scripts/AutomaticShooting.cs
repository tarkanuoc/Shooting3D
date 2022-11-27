using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShooting : Shooting
{
    public Animator anim;
    public float rmp;
    public AudioSource shootSound;
    
    public UnityEvent onShoot;

    private float _interval;
    private float _lastShoot;

    private void Start()
    {
        _interval = 60 / rmp;
       // _lastShoot = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
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
        anim.Play("Shoot", layer: -1, normalizedTime: 0);
        shootSound.Play();
        onShoot.Invoke();
    }

   
}
