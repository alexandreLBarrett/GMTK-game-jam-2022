using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAimWeapon : MonoBehaviour
{
    // Update is called once per frame
    private Transform _aimTransform;
    private Animator _animator;
    private AnimatorOverrideController _aoc;
    private PlayerStatsModifier _modifiers;
    [FormerlySerializedAs("isAvailable")] public bool weaponIsAvailable = true;

    public WeaponBehaviour selectedBehaviour;

    public AnimationClip[] idleAnimationClips;
    public AnimationClip[] moveAnimationClips;
    
    public GameObject currentWeapon;
    public float projectileSpawnOffset = 1f;
    private bool _canBeFired = true;

    public event EventHandler<OnShootEventArgs> OnShoot;

    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndpointPosition;
        public Vector3 shootPosition;
        public Quaternion gunEndpointRotation;
    }

    private void Awake()
    {
        _aimTransform = this.GetComponent<Transform>();
        _animator = this.GetComponentInParent<Animator>();
        _modifiers = GetComponentInParent<PlayerStatsModifier>();

        RandomizeWeapon();
    }

    public void RandomizeWeapon()
    {
        var behaviors = GetComponents<WeaponBehaviour>();
        var index = UnityEngine.Random.Range(0, behaviors.Length);
        selectedBehaviour = behaviors[index];
    }

    // protected AnimationClipOverrides 

    private void Start()
    {
        _aoc = new AnimatorOverrideController(_animator.runtimeAnimatorController);
        _animator.runtimeAnimatorController = _aoc;
    }

    void Update()
    {
        Shoot();
    }

    private void FixedUpdate()
    {
        Aim();
        OverrideAnimations();
    }

    private void Aim()
    {
        var mousePosition = Utils.GetMousePosition(transform.position);
        var aimDirection = (mousePosition - transform.position).normalized;
        var angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        _aimTransform.eulerAngles = new Vector3(0, 0, angle);

        var clipName = _animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
    }

    public void OverrideAnimations()
    {
        var rotation = (int)((_aimTransform.eulerAngles.z + 360) % 360 / 7.5);

        _aoc["Idle1"] = idleAnimationClips[rotation % 48];
        _aoc["Move 1"] = moveAnimationClips[rotation % 48];
    }

    private void Shoot()
    {
        // OnShoot?.Invoke(this, new OnShootEventArgs
        // {
        //     gunEndpointPosition = transform.position + transform.right * projectileSpawnOffset,
        //     gunEndpointRotation = transform.rotation,
        // });
        
        if (Input.GetButton("Fire1"))
        {
            var shootEndpoint = transform.position + transform.right * projectileSpawnOffset;
            Quaternion shootRotation = transform.rotation;
            selectedBehaviour.Shoot(shootEndpoint, shootRotation, _modifiers);
        }
    }
    
    

}