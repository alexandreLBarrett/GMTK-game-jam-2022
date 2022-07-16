using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    // Update is called once per frame
    private Transform _aimTransform;
    private Animator _animator;
    private AnimatorOverrideController _aoc; 
    
    public AnimationClip[] idleAnimationClips;
    public AnimationClip[] moveAnimationClips;

    public Rigidbody2D testProjectile;

    private Rigidbody2D bulletInstance;
    
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndpointPosition;
        public Vector3 shootPosition;
        
    }

    private void Awake()
    {
        _aimTransform = this.GetComponent<Transform>();
        _animator = this.GetComponentInParent<Animator>();
    }

    // protected AnimationClipOverrides 
    
    private void Start()
    {
        _aoc = new AnimatorOverrideController(_animator.runtimeAnimatorController);
        _animator.runtimeAnimatorController = _aoc;
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        Aim();
        OverrideAnimations();
    }

    private void Aim()
    {
        var mousePosition = Utils.GetMousePosition();

        var aimDirection = (mousePosition - transform.position).normalized;
        var angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        _aimTransform.eulerAngles = new Vector3(0, 0, angle);

        var clipName = _animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        
    }

    public void OverrideAnimations()
    {
        var rot = (int)((_aimTransform.eulerAngles.z + 360) % 360 / 7.5);

        _aoc["Idle1"] = idleAnimationClips[rot % 48];
        _aoc["Move 1"] = moveAnimationClips[rot % 48];
    }

    private void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            // OnShoot?.Invoke(this, new OnShootEventArgs
            // {
            //     gunEndpointPosition = transform.position,
            //     shootPosition = Utils.GetMousePosition(),
            // });
            
            bulletInstance = 
                Instantiate(testProjectile, transform.position, transform.rotation) 
                    as Rigidbody2D;

            bulletInstance.AddForce(transform.forward * 10f, ForceMode2D.Force);
            
        }
    }
}
