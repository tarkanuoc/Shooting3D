using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HitSurfaceType
{
    Dirt = 0,
    Blood = 1
}

public class HitEffectManager : Singleton<HitEffectManager>
{
    public HitEffectMapper[] effectMap;

    public GameObject GetEffectPrefab(HitSurfaceType surfaceType)
    {
        HitEffectMapper mapper = System.Array.Find(effectMap, x => x.surface == surfaceType);
        return mapper?.effectPrefab;
    }
}

[System.Serializable]
public class HitEffectMapper
{
    public HitSurfaceType surface;
    public GameObject effectPrefab;
}
