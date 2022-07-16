using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerStatsModifier : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

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
    [Range(.75f, 1.5f)]
    public float jumpHeight = 1f;
}
