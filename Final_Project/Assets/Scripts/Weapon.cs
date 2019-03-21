using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject gunBarrel;

    //public AudioClip impact;
    public AudioClip gunShot;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {

            Shoot();
            AudioSource.PlayClipAtPoint(gunShot, new Vector2(gunBarrel.transform.position.x, gunBarrel.transform.position.y));

        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
