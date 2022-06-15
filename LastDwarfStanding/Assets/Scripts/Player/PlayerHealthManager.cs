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

    private PlayerSoundManager _playerSoundManager;

    public Transform respawnPosition;
    private float _timeSinceDamage;
    public float timeToRecharge; 
    public float timeToStartRecharge; // how long befor it starts recharing
    public float rechargeRate = 10; // how much is recharged per second
    public float rechargeRateInerval = 1.0f;
    public float rechargeTimer = 0f;

    private ShieldManager _shieldManager;
    private CurrencyManager _currencyManager;
    private Shield _shield;


    private void Awake()
    {

        _shield = FindObjectOfType<Shield>();
        _currencyManager = GetComponent<CurrencyManager>();
        _shieldManager = FindObjectOfType<ShieldManager>();
        _playerSoundManager = GetComponent<PlayerSoundManager>();
    }
    void Start()
    {
        _timeSinceDamage = 0f;
        currentHealth = maxHealth;
        healthSlider.maxValue = currentHealth;
        _UpdateHealthBar();



        if (_shield == null) Debug.LogError("_shield is null");



    }

    void Update()
    {
        _timeSinceDamage += Time.deltaTime;

        //Debug.Log("Shield Active =" + _shieldManager.shieldActive);
     
            ShieldRegen();
        
    }

    private void ShieldRegen()
    {
        if (_shieldManager.shieldActive) return;

        //float regenTime = 0f;
        //float shieldValue = _shield.currentShield;

        if (_timeSinceDamage > timeToStartRecharge && _shield.currentShield < _shield.maxShield)
        {
            rechargeTimer += Time.deltaTime;

            if (rechargeTimer >= rechargeRateInerval)
            {
                rechargeTimer = 0;
                if (_shield.currentShield + rechargeRate >= _shield.maxShield)
                {
                    _shield.currentShield = _shield.maxShield;
                }
                else
                {
                    _shield.currentShield += rechargeRate;
                }
                _shieldManager.UpdateShieldBar();
            }
            
            //regenTime *= 1.005f;
            //regenTime += Time.deltaTime;
            //float lerpTime = regenTime / timeToRecharge;
            //_shieldManager.shieldSlider.value = Mathf.Lerp(shieldValue, _shield.maxShield, regenTime);
            //_shield.currentShield = _shieldManager.shieldSlider.value;
        }
    }

    public void TakeDamage(float damageToTake)
    {
        if (!_shieldManager.shieldActive || _shield.currentShield <= 0)
        {
            currentHealth -= damageToTake;
            
            _UpdateHealthBar();
            if (currentHealth <= 0)
            {
                
                _Ondeath();
                //SceneManager.LoadScene("DeathScene");
            }

        }
        else
        {
            _shieldManager.shield.ShieldDamage(damageToTake);
            _playerSoundManager.PlayAudioClip("ShieldDamage");
            _shieldManager.UpdateShieldBar();

        }
        _timeSinceDamage = 0f;
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

    private void _Ondeath()
    {
        if(_currencyManager.currentCurrencyAmount > 0)
        {
            _currencyManager.currentCurrencyAmount = _currencyManager.currentCurrencyAmount -= 5;
            _currencyManager.UpdateCurrencyText();
            if(_currencyManager.currentCurrencyAmount <= 0)
            {
                _currencyManager.currentCurrencyAmount = 0;
                _currencyManager.UpdateCurrencyText();
            }
        }
        transform.position = respawnPosition.transform.position;
        currentHealth = maxHealth;
        healthSlider.maxValue = currentHealth;
        _UpdateHealthBar();
    }
}
