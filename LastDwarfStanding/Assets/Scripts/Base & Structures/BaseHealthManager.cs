using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseHealthManager : MonoBehaviour
{

    public Slider baseHealthSlider;
    public float maxHealth;
    public float currentHealth;
    private float _timeSinceDamage;


    // Start is called before the first frame update
    void Start()
    {
        _timeSinceDamage = 0f;
        currentHealth = maxHealth;
        baseHealthSlider.maxValue = currentHealth;
        _UpdateBaseHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceDamage += Time.deltaTime;
    }



    private void _UpdateBaseHealthBar()
    {
        baseHealthSlider.value = currentHealth;
    }


    public void TakeDamage(float damageToTake)
    {

        currentHealth -= damageToTake;
        _UpdateBaseHealthBar();

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("DeathScene");
            _timeSinceDamage = 0f;
        }

    }
    public void BaseHealHealth(float healthToRecieve)
    {

        currentHealth += healthToRecieve;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        _timeSinceDamage = 0;

        _UpdateBaseHealthBar();
    }
}
