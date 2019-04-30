using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgBullet : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 15;
    public Rigidbody2D rb;


    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    void OnTriggerEnter2D(Collider2D hitTarget)
    {
        PlayerHealth player = hitTarget.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Debug.Log(player.health);
        }

        //AudioSource.PlayClipAtPoint(chargeUpSound, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
      
        Destroy(gameObject);
    }
}
