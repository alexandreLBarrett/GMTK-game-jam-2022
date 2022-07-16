using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public PlayerStatsModifier playerStatsModifier;

    private float horizontalMovement = 0;
    private float verticalMovement = 0;
    private bool jump = false;
    
    public float speed = 40f;

    private Animator _animator;
    
    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * (speed * playerStatsModifier.movementSpeed);

        if (Input.GetButtonDown("Jump"))
            jump = true;
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.deltaTime, false, jump, playerStatsModifier);
        Animate();
        jump = false;
    }

    private void Animate()
    {
        _animator.SetFloat("Movement", Mathf.Abs(horizontalMovement));
    }
}
