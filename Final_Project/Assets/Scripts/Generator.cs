using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Generator : MonoBehaviour
{
    public int health = 60;

    public GameObject destroyEffect;
    public GameObject forceGate;
    public GameObject reward;
    private AudioClip explosion;
    public AudioSource audioSource;

    public GameObject EnemyTypeToSpawn;
    public GameObject SpawnLocation1;
    public GameObject SpawnLocation2;
    public GameObject SpawnLocation3;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

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
        Instantiate(EnemyTypeToSpawn, SpawnLocation1.transform.position, Quaternion.identity);
        Instantiate(EnemyTypeToSpawn, SpawnLocation2.transform.position, Quaternion.identity);
        Instantiate(EnemyTypeToSpawn, SpawnLocation3.transform.position, Quaternion.identity);

        Destroy(gameObject);
        Destroy(forceGate);
        Destroy(destroyEffect);
        Instantiate(reward, transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
