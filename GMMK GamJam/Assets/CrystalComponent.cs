using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalComponent : MonoBehaviour
{
    DiceRotator rotator;
    // Start is called before the first frame update
    void Start()
    {
        rotator = GetComponentInParent<DiceRotator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rotator.RoomCleared();
        Destroy(gameObject);
    }
}
