using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMuzzle : MonoBehaviour
{
    public Transform muzzleImage;
    public float duration;

    private void Start()
    {
        HideMuzzle();    
    }

    public void ShowMuzzle()
    {
        muzzleImage.gameObject.SetActive(true);
        float angle = Random.Range(0, 360f);
        muzzleImage.localEulerAngles = new Vector3(0, 180f, angle);
        CancelInvoke();
        Invoke(nameof(HideMuzzle), duration);
    }

    private void HideMuzzle()
    {
        muzzleImage.gameObject.SetActive(false);
    }


}
