using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_AI : MonoBehaviour
{
    public GameObject player;
    public float turnRate, speed, fireRate;
    private int framesSinceDeath;
    private bool dying;
    private AudioSource audioSlave;
    public GameObject standardBullet;
    private GameObject currentShot;
    private int framesSinceLastShot;

    // Start is called before the first frame update
    void Start()
    {
        framesSinceLastShot = 0;
        framesSinceDeath = 0;
        audioSlave = GameObject.Find("AudioSlaveHolster").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //.LookAt(player.transform);
        //transform.rotation.eulerAngles.Set(0, 0, this.transform.rotation.eulerAngles.z);
        //transform.up = player.transform.position - transform.position;
        transform.up = Vector3.Lerp(transform.up, (player.transform.position - transform.position), turnRate * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //transform.Translate(speed * transform.up);
        if(dying == true)
        {
            framesSinceDeath++;
            if(framesSinceDeath >= 28)
            {
                Destroy(this.gameObject);
            }
        }
        if (framesSinceLastShot > 60 / fireRate)
        {
            currentShot = GameObject.Instantiate(standardBullet, this.transform.position + (this.transform.up * 2f), this.transform.rotation);
            currentShot.GetComponent<Projectile_Behavior>().velocity = -((player.transform.position * speed * Time.deltaTime) + (-currentShot.transform.up * currentShot.GetComponent<Projectile_Behavior>().shotSpeed));
            audioSlave.Play();
            framesSinceLastShot = 0;
        }
        framesSinceLastShot++;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        this.GetComponent<Animator>().SetTrigger("On Destroy");
        dying = true;
        this.GetComponent<AudioSource>().Play();
    }

           
}
