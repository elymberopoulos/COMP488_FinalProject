using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    float horiztonalMove = 0f;
    public float runSpeed = 40f;
    
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        horiztonalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horiztonalMove));

        /////////////Crouching////////////
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        /////////////Crouching////////////

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horiztonalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
