using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Generator : MonoBehaviour
{
    public int health = 60;

    public GameObject destroyEffect;
    public GameObject forceGate;
    public AudioClip[] destructionAudioClips;
    private AudioClip explosion;
    public AudioSource audioSource;

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
        for(int i = 0; i < destructionAudioClips.Length; i++)
        {
            explosion = destructionAudioClips[i];
        }
        Destroy(gameObject);
        Destroy(forceGate);
        Destroy(destroyEffect);
    }

    void Update()
    {
        
    }
}
