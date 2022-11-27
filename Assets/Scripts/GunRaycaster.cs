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
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMarkerPrefab, hitInfo.point, effectRotation);
            DeliveryDamage(hitInfo);
        }
    }

    private void DeliveryDamage(RaycastHit hitInfo)
    {
        Health health = hitInfo.collider.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }

    }
}
