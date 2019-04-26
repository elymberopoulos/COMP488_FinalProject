using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject gunBarrel;
    public AudioClip gunShot;

    bool flashLightOn = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            AudioSource.PlayClipAtPoint(gunShot, new Vector2(gunBarrel.transform.position.x, gunBarrel.transform.position.y));
            //animator.SetBool("Firing", true);
            //animator.SetBool("Firing", false);
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
