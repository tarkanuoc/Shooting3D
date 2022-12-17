using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : Singleton<ZombieManager>
{
    [SerializeField] private MissionController _mission;
    public void NotifyZombieKilled(Health health)
    {
        _mission.OnZombieKilled(gameObject);
    }
}
