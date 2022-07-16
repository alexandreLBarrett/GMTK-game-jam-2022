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

    private void Awake()
    {
        _aimTransform = this.GetComponent<Transform>();
        _animator = this.GetComponentInParent<Animator>();
        _aoc = new AnimatorOverrideController(_animator.runtimeAnimatorController);
        
    }

    void Update()
    {
        Aim();
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
    }

    private void Shoot()
    {
        if (Input.GetButton("Fire1"));
    }
}
