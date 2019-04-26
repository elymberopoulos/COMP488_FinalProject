using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Robot : MonoBehaviour
{
    public int health = 70;

    public GameObject destroyEffect;
    public GameObject removeSelf;
    public GameObject forceGate;
    public GameObject rewardedKey;
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

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        for (int i = 0; i < destructionAudioClips.Length; i++)
        {
            explosion = destructionAudioClips[i];
        }
        Instantiate(rewardedKey, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(removeSelf);
        Destroy(forceGate);
        Destroy(destroyEffect);
    }

    void Update()
    {

    }
}
