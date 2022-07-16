using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class DefaultWeaponBehaviour : MonoBehaviour
{
    [FormerlySerializedAs("_weaponSpeed")] public float weaponSpeed;
    [FormerlySerializedAs("_weaponStrenght")] public float weaponStrenght;
    [FormerlySerializedAs("_weaponBounciness")] public bool weaponBounciness = false;
   
    [FormerlySerializedAs("_weaponCooldown")] 
    [Range(0.2f, 5.0f)]
    public float weaponCooldown = 2f;
    
    private float _spawnOffset; 
    private PlayerStatsModifier _modifiers;
    private PlayerAimWeapon _playerAimWeapon;
    private bool _canBeFired = true;
    private void Start()
    {
        _modifiers = GetComponentInParent<PlayerStatsModifier>();
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * weaponSpeed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }

    public virtual void ShootBehaviour(Vector3 position, Quaternion rotation)
    {
        if (!_canBeFired)
            return;
        
        var bulletInstance = Instantiate(gameObject, position, rotation);
        bulletInstance.transform.localScale *= _modifiers.bulletSize;
        Debug.Log(position);
    }
}