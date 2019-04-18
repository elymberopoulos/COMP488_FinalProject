using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public GameObject flashLight;

    float horizontonalMove = 0f;
    public float runSpeed = 40f;
    public float jumpForce = 1200f;
    
    bool jump = false;
    bool crouch = false;
    bool grounded = false;
    bool flashLightOn = false;

    void Update()
    {
        horizontonalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontonalMove));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Conllison Enter");
        grounded = true;
        if (collision.gameObject.tag == "KILLZONE")
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collison Exit");
        grounded = false;
    }

    private void TurnOnFlashlight()
    {
        //Turn on flashlight
        if (Input.GetButtonDown("Fire2"))
        {
            
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontonalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
