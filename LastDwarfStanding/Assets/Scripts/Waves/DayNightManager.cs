using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class DayNightManager : MonoBehaviour
{

    public bool isDayTime;
    public float lengthOfDay = 20f;
    private float currentTime = 0f;
    public GameObject dayNightmother;
    public GameObject nightMaterial;
    public Animator nightAnimator;
    public Image[] sceneImages;
    public GameObject player;

   // public Image nightMaterialImage;
    

    // Start is called before the first frame update
    void Start()
    {
      //  nightMaterialImage = nightMaterial.GetComponent<Image>();
        nightMaterial = GetComponent<GameObject>();
        nightAnimator = GetComponent<Animator>();
        //sceneImages = FindObjectOfType<Image>();
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
        Vector3 newPosition = dayNightmother.transform.position;
        newPosition.x = player.transform.position.x;
        dayNightmother.transform.position = newPosition;
    }

    private void ToggleDayNight()
    {
        if (isDayTime)
        {
            isDayTime = false;
            ChangeNightTimeColours();
            



        }
        else
        {
            isDayTime = true;
            ChangeDayTimeColours();
        }
        ChangeNightTimeMaterial();
    }

    private void ChangeNightTimeMaterial()
    {
        if (isDayTime)
        {
           // nightMaterialImage.color = new Color(nightMaterialImage.color.r, nightMaterialImage.color.g, nightMaterialImage.color.b, 1f);
            nightMaterial.gameObject.SetActive(false);
            nightAnimator.SetTrigger("Fade Out");
        }
        else
        {
            //nightMaterialImage.color = new Color(nightMaterialImage.color.r, nightMaterialImage.color.g, nightMaterialImage.color.b, 0f);
            nightMaterial.gameObject.SetActive(true);
            nightAnimator.SetTrigger("Fade In");
        }
    }
    private void ChangeNightTimeColours()
    {
        Debug.Log("Changing colour at night");
        foreach(Image image in sceneImages)
        {
            image.GetComponent<Image>().color = new Color32(119, 122, 154, 255);
        }
        
    }

    private void ChangeDayTimeColours()
    {
        Debug.Log("Changing colour at day");
        foreach (Image image in sceneImages)
        {
            image.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

    }
}
