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

    public float angleBetween;
    public float shotCount = 1;

    public string label;

    protected bool weaponIsAvailable = true;

    public void Shoot(Vector3 position, Quaternion rotation, PlayerStatsModifier modifiers)
    {
        if (!weaponIsAvailable)
            return;

        var coneWidth = shotCount * angleBetween;
        rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z - coneWidth/2);

        for (int i = 0; i < shotCount; ++i)
        {
            rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z + angleBetween);
            var bulletInstance = Instantiate(bulletType, position, rotation);
            var bullet = bulletInstance.AddComponent<Bullet>();
            bullet.ApplyBehaviour(this, modifiers);
        }

        StartCoroutine(StartCooldown(modifiers));
    }

    public IEnumerator StartCooldown(PlayerStatsModifier modifiers)
    {
        weaponIsAvailable = false;
        yield return new WaitForSeconds(1/(FireRate * modifiers.fireRate) * 60);
        weaponIsAvailable = true;
    }
}