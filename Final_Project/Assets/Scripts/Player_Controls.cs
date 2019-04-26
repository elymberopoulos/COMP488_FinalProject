using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controls : MonoBehaviour
{
    private Vector3 currentVelocity;
    public float acceleration, maxSpeed, frictionFactor, turnSpeed, gasPetalPenalty, fireRate;
    public GameObject standardBullet;
    private GameObject currentShot;
    private int framesSinceLastShot, framesSinceDeath;
    private bool dying;
    // Start is called before the first frame update
    void Start()
    {
        currentVelocity = Vector3.zero;
        framesSinceLastShot = 0;
        framesSinceDeath = 0;
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
                this.GetComponent<AudioSource>().Play();
                framesSinceLastShot = 0;
            }
        }
        framesSinceLastShot++;

        if (dying == true)
        {
            framesSinceDeath++;
            if (framesSinceDeath >= 28)
            {
                Destroy(this.gameObject);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera_Behavior>().GameOver();
            }
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Finish")
        {
        SceneManager.LoadScene(1);
        }

        if(col.gameObject.tag == "Enemy" ||col.gameObject.tag == "Hazard" || col.gameObject.tag == "Bullet")
        {
            this.GetComponent<Animator>().SetTrigger("OnDestroy");
            dying = true;
            foreach(GameObject gO in GameObject.FindGameObjectsWithTag("Decorators"))
            {
                gO.SetActive(false);
            }
            this.GetComponent<AudioSource>().Play();
        }

        if(col.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(sceneName: "SpaceLevel_2(dark)");
        }
    }
}
