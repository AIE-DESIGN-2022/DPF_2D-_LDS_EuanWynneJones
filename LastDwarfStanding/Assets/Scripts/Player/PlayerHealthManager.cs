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
    private float _timeToRecharge;

    private ShieldManager _shieldManager;
    private Shield _Shield;
    

 
    void Start()
    {

        currentHealth = maxHealth;
        healthSlider.maxValue = currentHealth;
        _UpdateHealthBar();

        _Shield = FindObjectOfType<Shield>();   
        _shieldManager = FindObjectOfType<ShieldManager>();
    }

    void Update()
    {
        _timeSinceDamage += Time.deltaTime;
    }

    public void TakeDamage(float damageToTake)
    {
        if (!_shieldManager.shieldActive)
        {
            currentHealth -= damageToTake;
            _UpdateHealthBar();
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("DeathScene");
            }

        }
        else
        {
            _shieldManager.shield.ShieldDamage(damageToTake);
            _shieldManager.UpdateShieldBar();
            if((_shieldManager.shieldActive) && _Shield.currentShield <= 0)
            {
            Debug.Log("Shield Broken making inactive");
                _shieldManager.shieldActive = false;
                _Shield.gameObject.SetActive(false);    
            }
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
