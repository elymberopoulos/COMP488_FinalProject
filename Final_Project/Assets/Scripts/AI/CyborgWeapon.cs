using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject cyborgBullet;
    public AudioClip fireSound;

    public void Shoot()
    {
        Debug.Log("Cyborg Weapon Shot");
        AudioSource.PlayClipAtPoint(fireSound, new Vector2(firePoint.transform.position.x, firePoint.transform.position.y));
        Instantiate(cyborgBullet, firePoint.position, firePoint.rotation);
    }
}

