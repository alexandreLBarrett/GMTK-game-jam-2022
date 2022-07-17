using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed;
    int damage;

    public void ApplyBehaviour(WeaponBehaviour behaviour, PlayerStatsModifier modifier)
    {
        speed = behaviour.BulletSpeed * modifier.bulletSpeed;
        damage = (int)(behaviour.Damage * modifier.damage);

        transform.localScale *= (behaviour.BulletSize * modifier.bulletSize);
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
            return;

        var hpBar = collision.gameObject.GetComponent<HpBar>();

        if (hpBar != null)
        {
            if (!hpBar.friendly)
            {
                hpBar.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
