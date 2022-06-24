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
        UpdateBaseHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceDamage += Time.deltaTime;
    }



    public void UpdateBaseHealthBar()
    {
        baseHealthSlider.maxValue = maxHealth;
        baseHealthSlider.value = currentHealth;
    }


    public void TakeDamage(float damageToTake)
    {

        currentHealth -= damageToTake;
        UpdateBaseHealthBar();

        if (currentHealth <= 0)
        {
            EnemyWaveManager enemyWaveManager = FindObjectOfType<EnemyWaveManager>();
            SavingSystem savingSystem = FindObjectOfType<SavingSystem>();
            Dictionary<string, object> waveStats = new Dictionary<string, object>();
            //print("Wave count = "  + enemyWaveManager.waveCount);
            waveStats.Add("waveCount", (object)enemyWaveManager.WaveCount);
            savingSystem.EndGameSave(waveStats);

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

        UpdateBaseHealthBar();
    }
}
