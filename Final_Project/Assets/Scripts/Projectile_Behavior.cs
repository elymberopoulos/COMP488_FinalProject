using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Behavior : MonoBehaviour
{
    public int shotSpeed;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(velocity * Time.deltaTime, Space.World);

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "invulnerable")
        {
            Destroy(collision.gameObject);
        }
    }
}
