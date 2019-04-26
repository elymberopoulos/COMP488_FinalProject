using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public GameObject flashLight;
    public AudioClip KeyPickupSound;
    public AudioClip DoorOpenSound;
    public AudioClip DoorLockedSound;


    float horizontonalMove = 0f;
    public float runSpeed = 40f;
    public float jumpForce = 1200f;
    
    bool jump = false;
    bool crouch = false;
    bool grounded = false;
    bool flashLightOn = false;
    bool hasYellowKey = false;
    bool hasRedKey = false;


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

        if(collision.gameObject.tag == "YellowKey")
        {
            GameObject key = GameObject.FindWithTag("YellowKey");
            AudioSource.PlayClipAtPoint(KeyPickupSound, new Vector2(key.transform.position.x, key.transform.position.y));
            Destroy(key);
            hasYellowKey = true;
        }

        if(collision.gameObject.tag == "YellowForceDoor" & hasYellowKey)
        {
            GameObject ForceDoor = GameObject.FindWithTag("YellowForceDoor");
            AudioSource.PlayClipAtPoint(DoorOpenSound, new Vector2(ForceDoor.transform.position.x, ForceDoor.transform.position.y));
            Destroy(ForceDoor);
        }
        if (collision.gameObject.tag == "YellowForceDoor" & !hasYellowKey)
        {
            GameObject ForceDoor = GameObject.FindWithTag("YellowForceDoor");
            AudioSource.PlayClipAtPoint(DoorLockedSound, new Vector2(ForceDoor.transform.position.x, ForceDoor.transform.position.y));
 
        }

        if (collision.gameObject.tag == "RedKey")
        {
            GameObject key = GameObject.FindWithTag("RedKey");
            AudioSource.PlayClipAtPoint(KeyPickupSound, new Vector2(key.transform.position.x, key.transform.position.y));
            Destroy(key);
            hasRedKey = true;
        }

        if (collision.gameObject.tag == "RedForceDoor" & hasRedKey)
        {
            GameObject ForceDoor = GameObject.FindWithTag("RedForceDoor");
            AudioSource.PlayClipAtPoint(DoorOpenSound, new Vector2(ForceDoor.transform.position.x, ForceDoor.transform.position.y));
            Destroy(ForceDoor);

        }
        if (collision.gameObject.tag == "RedForceDoor" & !hasRedKey)
        {
            GameObject ForceDoor = GameObject.FindWithTag("RedForceDoor");
            AudioSource.PlayClipAtPoint(DoorLockedSound, new Vector2(ForceDoor.transform.position.x, ForceDoor.transform.position.y));

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
