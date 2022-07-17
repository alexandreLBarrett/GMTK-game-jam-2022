using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponBehaviour : MonoBehaviour, IShootable
{
    public GameObject bulletType;
    public float FireRate; // seconds between rounds
    public int Damage;
    public float BulletSize;
    public float BulletSpeed;

    public string label;

    protected bool weaponIsAvailable = true;

    public void Shoot(Vector3 position, Quaternion rotation, PlayerStatsModifier modifiers)
    {
        if (!weaponIsAvailable)
            return;

        var bulletInstance = Instantiate(bulletType, position, rotation);
        var bullet = bulletInstance.AddComponent<Bullet>();
        bullet.ApplyBehaviour(this, modifiers);

        StartCoroutine(StartCooldown(modifiers));
    }

    public IEnumerator StartCooldown(PlayerStatsModifier modifiers)
    {
        weaponIsAvailable = false;
        yield return new WaitForSeconds(FireRate * modifiers.fireRate);
        weaponIsAvailable = true;
    }
}