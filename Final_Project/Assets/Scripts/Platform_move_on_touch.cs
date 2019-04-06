﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_move_on_touch : MonoBehaviour
{
    public GameObject platform;

    public float moveSpeed;

    public Transform currentPoint;

    public Transform[] points;

    public int pointSelection;

    private bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = points[pointSelection];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
            moving = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {



           
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, maxDistanceDelta: Time.deltaTime * moveSpeed);

            if (platform.transform.position == currentPoint.position)
            {
                pointSelection++;

                if (pointSelection == points.Length)
                {
                    pointSelection = 0;
                }

                currentPoint = points[pointSelection];
            }
                
        }

    }
}