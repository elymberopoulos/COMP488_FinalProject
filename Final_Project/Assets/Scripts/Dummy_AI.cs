using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_AI : MonoBehaviour
{
    GameObject player;
    public GameObject bulletType;
    public float speed, turnRate, fireRate;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);

        transform.Translate(transform.up * speed * Time.deltaTime);
    }
}
