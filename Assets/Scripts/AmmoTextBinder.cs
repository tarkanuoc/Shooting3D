using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoTextBinder : MonoBehaviour
{
    public TextMeshProUGUI txtAmmo;
    public GunAmmo gunAmmo;

    private void Start()
    {
        gunAmmo.loadedAmmoChanged.AddListener(UpdateGunAmmo);
        UpdateGunAmmo();
    }

    public void UpdateGunAmmo()
    {
        txtAmmo.text = gunAmmo.LoadedAmo.ToString();
    }
}
