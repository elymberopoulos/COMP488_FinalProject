using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_AI : MonoBehaviour
{
    public GameObject player;
    public float turnRate, speed;
    private int framesSinceDeath;
    private bool dying;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        this.GetComponent<Animator>().SetTrigger("On Destroy");
        dying = true;
    }
}
