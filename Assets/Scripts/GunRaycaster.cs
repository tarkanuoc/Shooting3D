using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycaster : MonoBehaviour
{
    public GameObject hitMarkerPrefab;
    public Camera camera;
    public LayerMask layerMask;
    public int damage;


    public void PerfomeRaycast()
    {
        Ray aimingRay = new Ray(camera.transform.position, camera.transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            //Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            // Instantiate(hitMarkerPrefab, hitInfo.point, effectRotation);
            ShowHitEffect(hitInfo);
            DeliveryDamage(hitInfo);
        }
    }

    private void ShowHitEffect(RaycastHit hitInfo)
    {
        HitSurface hitSurface = hitInfo.collider.GetComponent<HitSurface>();
        if (hitSurface != null)
        {
            GameObject effectPrefab = HitEffectManager.Instance.GetEffectPrefab(hitSurface.surfaceType);
            if (effectPrefab != null)
            {
                Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
                Instantiate(effectPrefab, hitInfo.point, effectRotation);
            }
        }
    }

    private void DeliveryDamage(RaycastHit hitInfo)
    {
        Health health = hitInfo.collider.GetComponentInParent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }

    }
}
