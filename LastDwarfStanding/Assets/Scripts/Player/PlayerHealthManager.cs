using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealthManager : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth;
    public float currentHealth;

    private float _timeSinceDamage;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = currentHealth;
        _UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceDamage += Time.deltaTime;
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
    public void RecieveHealth(float healthToRecieve)
    {

        currentHealth += healthToRecieve;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        _timeSinceDamage = 0;
        _UpdateHealthBar();
    }
    private void _UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
    }
}
