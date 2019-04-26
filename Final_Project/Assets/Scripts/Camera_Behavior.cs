using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Behavior : MonoBehaviour
{
    public Text gameOver;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10.1f);
    }

    public void GameOver()
    {
        gameOver.enabled = true;
    }
}
