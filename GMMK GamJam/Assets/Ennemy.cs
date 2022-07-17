using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;

public class Ennemy : MonoBehaviour, IEnemy
{
    Transform destination;
    private AIPath _path;
    
    public int damageDone = 20;

    private void Start()
    {
        destination = GetComponent<AIDestinationSetter>().target;
        _path = GetComponent<AIPath>();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, destination.position.z);
        GetComponentInChildren<Animator>().SetFloat("move", _path.hasPath ? 1 : 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Character")
        {
            collision.gameObject.GetComponent<HpBar>().TakeDamage(damageDone);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GameObject().name.Equals("Character")) ;
        {
            destination.GameObject().GetComponent<HpBar>().TakeDamage(damageDone);
        }
    }
}

public interface IEnemy
{
}
