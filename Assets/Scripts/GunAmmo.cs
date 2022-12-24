using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class GunAmmo : MonoBehaviour
{
    //[SerializeField] private GrenadeLauncher gun;
    [SerializeField] private Animator anim;
    public UnityEvent loadedAmmoChanged;
    public Shooting shooting;

    public AudioSource[] reloadingSound;
    
    public int magSize;

    [SerializeField] private int _loadedAmo;
    public bool isReloading;
    public int LoadedAmo
    {
        get => _loadedAmo;

        set
        {
            _loadedAmo = value;
            loadedAmmoChanged.Invoke();
            if (_loadedAmo <= 0)
            {
                Reload();
            }
            else
            {
               // UnlockShooting();
            }
            Debug.Log("========= set ammo " + _loadedAmo);
        }
    }

    private void Start()
    {
        RefillAmmo();
    }

    private void LockShooting()
    {
        //   shooting.enabled = false;
        shooting.IsLocked = true;
    }

    private void UnlockShooting()
    {
        Debug.Log("============= Unlock Shooting");
        Debug.Log("========== ammo = " + LoadedAmo);
        shooting.enabled = true;
        shooting.IsLocked = false;
    }

    public void AddAmmo()
    {
        RefillAmmo();
    }

    private void RefillAmmo()
    {
        LoadedAmo = magSize;
        UnlockShooting();
    }

    public void SingleFireAmmoCounter()
    {
        if (LoadedAmo == 0) return;
        LoadedAmo--;
        Debug.Log("========== ammo = " + LoadedAmo);
    }

    public void Reload()
    {
        anim.SetTrigger("Reload");
        LockShooting();
        isReloading = true;
        DOVirtual.DelayedCall(4f, () => {
            ReloadToIdle();
        });
    }

    public void ReloadToIdle()
    {
        Debug.Log("========= reload to idle");
        if (LoadedAmo < 0) return;
        shooting.enabled = true;
        isReloading = false;
        AddAmmo();
    }
       

    private void Update()
    {
        if (isReloading) return;
       
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    Reload();
        //}

        if (_loadedAmo <= 0)
        {
            Reload();
        }
    }

    public void OnSelected() => ReloadToIdle();
    public void OnGunSelected() => UpdateShootingLock();
    private void UpdateShootingLock() => shooting.enabled = _loadedAmo > 0;
    public void PlayReloadPart1Sound() => reloadingSound[0].Play();
    public void PlayReloadPart2Sound() => reloadingSound[1].Play();
    public void PlayReloadPart3Sound() => reloadingSound[2].Play();
    public void PlayReloadPart4Sound() => reloadingSound[3].Play();
    public void PlayReloadPart5Sound() => reloadingSound[4].Play();

}
