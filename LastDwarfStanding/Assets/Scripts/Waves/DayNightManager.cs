using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{

    public bool isDayTime;
    public float lengthOfDay = 20f;
    private float currentTime = 0f;
    public GameObject nightMaterial;
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        isDayTime = true;
        ChangeNightTimeMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        //print("CurrentTime = " + currentTime);

        if (currentTime > lengthOfDay)
        {
            currentTime = 0f;
            ToggleDayNight();
            //Debug.Log("Day Night swiching");
        }

        ChangePosition();

    }

    private void ChangePosition()
    {
        Vector3 newPosition = nightMaterial.transform.position;
        newPosition.x = player.transform.position.x;
        nightMaterial.transform.position = newPosition;
    }

    private void ToggleDayNight()
    {
        if (isDayTime)
        {
            isDayTime = false;
            
        }
        else
        {
            isDayTime = true;
        }
        ChangeNightTimeMaterial();
    }

    private void ChangeNightTimeMaterial()
    {
        if (isDayTime)
        {
            nightMaterial.gameObject.SetActive(false);
        }
        else
        {
            nightMaterial.gameObject.SetActive(true);
        }
    }
}
