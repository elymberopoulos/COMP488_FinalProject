using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyborg : MonoBehaviour
{
    public int health = 85;
    public float speed;
    private float baseSpeed;
    public float distance;
    private bool movingRight = true;
    private bool alive = true;
    private Vector2 direction = new Vector2(1, 0);
    public GameObject deathAnimation;
    public Transform groundDetection;
    public AudioClip deathSound;
    public Animator animator;


    void Start()
    {
        animator.SetFloat("MoveSpeed", speed);
        baseSpeed = speed;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetInteger("CyborgHealth", health);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        speed = 0;
        Instantiate(deathAnimation, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(deathSound, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
        Destroy(gameObject);
    }
    /*
    IEnumerator DestroyGameObject(float time)
    {
        yield return new WaitForSeconds(time);

    }
    */
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D rightCheck = Physics2D.Raycast(groundDetection.transform.position, direction, distance);
        //RaycastHit2D leftCheck = Physics2D.Raycast(checkLeft.transform.position, Vector2.left, distance);
        RaycastHit2D ledgeInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        animator.SetFloat("MoveSpeed", speed);
        animator.SetInteger("CyborgHealth", health);


        if (rightCheck == true)
        {
            if (rightCheck.collider.CompareTag("Player") && Time.frameCount % 85 == 0)
            {
                //speed = 0;
                CyborgWeapon weapon = GetComponent<CyborgWeapon>();
                weapon.Shoot();
                Debug.Log("RAYCAST ON PLAYER");
            }
            else if (rightCheck.collider.CompareTag("Wall") || 
                rightCheck.collider.CompareTag("YellowForceDoor") || 
                rightCheck.collider.CompareTag("RedForceDoor"))
            {
                if (movingRight)
                {
                    Debug.Log("Right Wall hit");

                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = !movingRight;
                    direction *= -1;
                }
                else if (!movingRight)
                {
                    Debug.Log("Left Wall hit");

                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = !movingRight;
                    direction *= -1;
                }
            }

        }

        if (ledgeInfo == false)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = !movingRight;
            }
            else if(!movingRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = !movingRight;
            }
        }
    }

}
