using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject prefabExplosion;
    public float explosionRadius;
    public float explosionForce;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(prefabExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
        BlowObject();
    }

    void BlowObject()
    {
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        for (int i = 0; i < affectedObjects.Length; i++)
        {
            Rigidbody rigibody = affectedObjects[i].attachedRigidbody;
            if (rigibody)
            {
                rigibody.AddExplosionForce(explosionForce, transform.position, explosionRadius
                    , 10, ForceMode.Impulse);
            }
        }
    }

}
