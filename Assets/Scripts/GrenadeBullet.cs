using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    public GameObject prefabExplosion;
    public float explosionRadius;
    public float explosionForce;
    public int damage;

    private List<Health> oldVictims = new List<Health>();

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(prefabExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
        BlowObject();
    }

    private void DeliverDamage(Collider victim)
    {
        //Health health = victim.GetComponent<Health>();
        Health health = victim.GetComponentInParent<Health>();
        //if (health != null)
        if (health != null && !oldVictims.Contains(health))
        {
            health.TakeDamage(damage);
            oldVictims.Add(health);
        }
    }

    void BlowObject()
    {
        oldVictims.Clear();
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        for (int i = 0; i < affectedObjects.Length; i++)
        {
            Rigidbody rigibody = affectedObjects[i].attachedRigidbody;
            if (rigibody)
            {
                rigibody.AddExplosionForce(explosionForce, transform.position, explosionRadius
                    , 10, ForceMode.Impulse);
                DeliverDamage(affectedObjects[i]);
            }
        }
    }

}
