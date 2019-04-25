using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPlatform : MonoBehaviour
{
    public Collider2D platform;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(platform.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
