using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashLight;
    public Transform flashLightLocation;

    bool flashLightOn = false;

    void Update()
    {
        //Turn on flashlight
        if (Input.GetButtonDown("Fire2") && flashLightOn == false)
        {
            TurnOnLight();
            flashLightOn = true;
        }
        //Turn off flashlight
        if (Input.GetButtonDown("Fire2") && flashLightOn == true)
        {
            TurnOffLight();
            flashLightOn = false;
        }
    }
    private void TurnOnLight()
    {
        Instantiate(flashLight, flashLightLocation);
    }
    private void TurnOffLight()
    {
        GameObject[] light = GameObject.FindGameObjectsWithTag("Flashlight");
        for(int i = 1; i < light.Length; i++)
        {
            Destroy(light[i].gameObject);
        }

    }
}
