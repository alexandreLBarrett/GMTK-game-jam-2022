using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;

public class Ennemy : Objective
{
    Transform destination;
    private AIPath _path;
    
    public int damageDone = 20;
    [SerializeField] private HpBar _hpBar;

    protected new void Start()
    {
        base.Start();
        destination = GetComponent<AIDestinationSetter>().target;
        _path = GetComponent<AIPath>();
        _hpBar.OnDeath += EnnemyDeath;
    }

    protected new void OnEnable()
    {
        base.OnEnable();
    }

    private void EnnemyDeath(object sender, Utils.OnStuffDeathEventArgs e)
    {
        Completed();
        Destroy(gameObject);
    }

    private void Update()
    {
        GetComponentInChildren<Animator>().SetFloat("move", _path.hasPath ? 1 : 0);
        GetComponentInChildren<SpriteRenderer>().flipY = destination.transform.position.x > transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GameObject().TryGetComponent<HpBar>(out HpBar hpBar))
        {
            if (hpBar.friendly && hpBar._canBeHurt)
            {
                hpBar.TakeDamage(damageDone);
                hpBar.StartCooldownCorutine();
            }
        }
    }
}

public interface IEnemy
{
    public abstract void DealDamage();

    public abstract void TakeDamage();
}

