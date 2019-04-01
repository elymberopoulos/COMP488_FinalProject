using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 20;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitTarget)
    {
        Generator generator = hitTarget.GetComponent<Generator>();
        if(generator != null)
        {
            generator.TakeDamage(damage);
            Debug.Log(generator.health);
        }
        Destroy(gameObject);
    }
}
