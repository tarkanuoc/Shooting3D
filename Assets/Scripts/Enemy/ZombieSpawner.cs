using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _zombiePrefab;

    public int SpawnQuantity;
    public float SpawnInterval;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnZombieByTime());
    }
    IEnumerator SpawnZombieByTime()
    {
        while (SpawnQuantity > 0)
        {
            SpawnZombie();
            yield return new WaitForSeconds(SpawnInterval);
        }
    }

    private void SpawnZombie()
    {
        Instantiate(_zombiePrefab, transform.position, transform.rotation);
        SpawnQuantity--;
    }
}
