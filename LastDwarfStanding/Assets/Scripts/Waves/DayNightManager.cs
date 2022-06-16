using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{

    public bool isDayTime;
    public float lengthOfDay = 20f;
    public float currentTime = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        isDayTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > lengthOfDay)
        {
            currentTime = 0f;
            ToggleDayNight();
            Debug.Log("Day Night swiching");
        }

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
    }
}
