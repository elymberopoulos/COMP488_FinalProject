using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 20;
    public Rigidbody2D rb;
    public AudioClip boom1;
    public AudioClip boom2;
    public AudioClip boom3;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitTarget)
    {
        Generator generator = hitTarget.GetComponent<Generator>();
        Cyborg cyborg = hitTarget.GetComponent<Cyborg>();
        if(generator != null)
        {
            generator.TakeDamage(damage);
            Debug.Log(generator.health);
        }
        if(cyborg != null)
        {
            cyborg.TakeDamage(damage);
            Debug.Log(cyborg.health);
        }
        
        int x = Random.Range(0, 3);
        switch (x)
        {
            case 0:
                AudioSource.PlayClipAtPoint(boom1, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
                break;
            case 1:
                AudioSource.PlayClipAtPoint(boom2, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
                break;
            case 2:
                AudioSource.PlayClipAtPoint(boom3, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
                break;
            default:
                break;
                

        }
        Destroy(gameObject);
    }
}
