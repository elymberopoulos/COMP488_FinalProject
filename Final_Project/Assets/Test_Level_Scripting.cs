using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Level_Scripting : MonoBehaviour
{
    public GameObject defaultEnemy;
    int framesSinceLastSpawn, framesUntilNextSpawn;
    float spawnNumber;
    // Start is called before the first frame update
    void Start()
    {
        framesSinceLastSpawn = 0;
        framesUntilNextSpawn = 360;
    }

    // Update is called once per frame
    void Update()
    {
        if(framesSinceLastSpawn > framesUntilNextSpawn)
        {
            spawnNumber = Random.Range(0f, 200f);
            if(spawnNumber <= 50f)
            {
                GameObject.Instantiate(defaultEnemy, new Vector3(spawnNumber - 25, 25, 0), Quaternion.Euler(Vector3.zero));
            }else if(spawnNumber <= 100f)
            {
                GameObject.Instantiate(defaultEnemy, new Vector3(25, spawnNumber - 75, 0), Quaternion.Euler(Vector3.zero));
            }else if (spawnNumber <= 150f)
            {
                GameObject.Instantiate(defaultEnemy, new Vector3(spawnNumber - 125, -25, 0), Quaternion.Euler(Vector3.zero));
            }else{
                GameObject.Instantiate(defaultEnemy, new Vector3(-25, spawnNumber - 175, 0), Quaternion.Euler(Vector3.zero));
            }
            framesUntilNextSpawn = Random.Range(300, 480);
            framesSinceLastSpawn = 0;
        }
        framesSinceLastSpawn++;
    }
}
