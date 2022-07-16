using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Ennemy : MonoBehaviour
{
    Transform destination;
    private void Start()
    {
        destination = GetComponent<AIDestinationSetter>().target;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, destination.position.z);
    }
}
