﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controls : MonoBehaviour
{
    private Vector3 currentVelocity;
    public float acceleration, maxSpeed, frictionFactor, turnSpeed, gasPetalPenalty, fireRate;
    public GameObject standardBullet;
    private GameObject currentShot;
    private int framesSinceLastShot;
    // Start is called before the first frame update
    void Start()
    {
        currentVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Controls
        if (Mathf.Abs(Input.GetAxis("Vertical")) == 1)
        {
            this.transform.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal") * -4) * Time.deltaTime * turnSpeed * (1 - (gasPetalPenalty * Time.deltaTime)));
        }
        else
        {
            this.transform.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal") * -4) * Time.deltaTime * turnSpeed);
        }
        //currentVelocity += new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        currentVelocity += (-transform.up * Input.GetAxis("Vertical") * Time.deltaTime * acceleration);
        currentVelocity = new Vector3(currentVelocity.x, currentVelocity.y, 0);
        currentVelocity = currentVelocity.normalized * currentVelocity.magnitude * (1 - (frictionFactor * Time.deltaTime));
        if(currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }
        this.transform.Translate(currentVelocity * Time.deltaTime, Space.World);

        //Firing Controls
        
        if(Input.GetAxis("Fire1") == 1)
        {
            if (framesSinceLastShot > 60 / fireRate)
            {
                currentShot = GameObject.Instantiate(standardBullet, this.transform.position - (this.transform.up * 0.3f), this.transform.rotation);
                currentShot.GetComponent<Projectile_Behavior>().velocity = currentVelocity + (-currentShot.transform.up * currentShot.GetComponent<Projectile_Behavior>().shotSpeed);
                framesSinceLastShot = 0;
            }
        }
        framesSinceLastShot++;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Finish")
        {
        SceneManager.LoadScene(1);
        }
    }
}