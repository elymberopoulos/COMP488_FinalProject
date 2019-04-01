using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int health = 60;

    public GameObject destroyEffect;
    public GameObject forceGate;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(forceGate);
        Destroy(destroyEffect);
    }

    void Update()
    {
        
    }
}
