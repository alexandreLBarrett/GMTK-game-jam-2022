using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerStatsModifier : MonoBehaviour
{
    float maxModify = 0.3f;
    float minModify = -0.3f;

    [Range(.1f, 2f)]
    public float fireRate = 1f; // bullets per seconds
    [Range(.1f, 2f)]
    public float damage = 1f;
    [Range(.1f, 2f)]
    public float bulletSize = 1f;
    [Range(.1f, 2f)]
    public float bulletSpeed = 1f;
    [Range(.1f, 2f)]
    public float movementSpeed = 1f;

    public void RandomizeStats()
    {
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);

        fireRate += GetRandomModifier();
        Limit(ref fireRate);
        damage += GetRandomModifier();
        Limit(ref damage);
        bulletSize += GetRandomModifier();
        Limit(ref bulletSize);
        bulletSpeed += GetRandomModifier();
        Limit(ref bulletSpeed);
        movementSpeed += GetRandomModifier();
        Limit(ref movementSpeed);
    }

    void Limit(ref float value)
    {
        value = Mathf.Clamp(value, .5f, 1.5f);
    }

    float GetRandomModifier()
    {
        return UnityEngine.Random.Range(minModify, maxModify);
    }
}
