using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using System;

public class EnemyWaveManager : MonoBehaviour
{

    public bool waveStarted = false;
    //public float waveTimer = 0f;
    //public float waveTimeLimit = 10f;
    //public float waveBreakTimer = 0f;
    //public float waveBreakTimeLimit = 5f;

    [Header("New Way")]
    private Animator waveAnimation;
    private DayNightManager dayNightManager;
    public List<GameObject> currentWave = new List<GameObject>();
    private EnemySpawner enemySpawner;
    private int waveCount = 1;
    public Text waveTextNumber;
    public float spawnRate = 0.5f;
    private float spawnTimer = 0;
    private int spawnedEnemies = 0;
    private int enemiesToSpawn = 0;
    private bool nextDayHasHappened = true;

    // Start is called before the first frame update
    void Start()
    {
        waveAnimation = gameObject.GetComponent<Animator>();
        dayNightManager = FindObjectOfType<DayNightManager>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        //waveBreakTimer += Time.deltaTime;
        //waveCount = 0;
        //WaveBreak();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!waveStarted)
        {
            WaveBreak();

        }
        else
        {
            Wave();
        }*/

        if (!dayNightManager.isDayTime)
        {
            CreateWave(waveCount);
            SpawnWave();
            
        }

        CheckIfWaveFinished();
        CheckIfNextDayHappeded();
    }

    private void CheckIfNextDayHappeded()
    {
        if (nextDayHasHappened) return;

        if (waveStarted && dayNightManager.isDayTime)
        {
            nextDayHasHappened = true;
        }
    }

/*    public void Wave()
    {
        waveStarted = true;
        waveTimer += Time.deltaTime;
        

        if (waveTimer >= waveTimeLimit)
        {
            waveStarted = false;

            waveBreakTimer = 0f;
            WaveBreak();

        }
*/
        

    

    private void CheckIfWaveFinished()
    {
        if (waveStarted && currentWave.Count == 0)
        {
            waveStarted = false;
            waveCount++;
        }
    }

/*    public void WaveBreak()
    {
        waveBreakTimer += Time.deltaTime;

        if (waveBreakTimer >= waveBreakTimeLimit)
        {
            waveTimer = 0f;
            waveCount++;
            UpdateWaveText();
            waveAnimation.SetTrigger("TriggerWaveText");
            Wave();
            

        }
    }*/

    public void UpdateWaveText()
    {
        waveAnimation.SetTrigger("TriggerWaveText");
        waveTextNumber.text = waveCount.ToString();
    }

    private void CreateWave(int waveNumber)
    {
        if (waveStarted || !nextDayHasHappened) return;

        int numberOfEnemies = waveNumber * 3;

        enemiesToSpawn = numberOfEnemies;
        spawnedEnemies = 0;
        spawnTimer = 0f;

        waveStarted = true;
        nextDayHasHappened = false;
        UpdateWaveText();
        
    }

    private void SpawnWave()
    {
        if (waveStarted) return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnRate && spawnedEnemies < enemiesToSpawn)
        {
            currentWave.Add(enemySpawner.SpawnEmemy());
            spawnedEnemies++;
            spawnTimer = 0;
        }    
    }

    public void EnemnyDied(GameObject enemy)
    {
        currentWave.Remove(enemy);
    }

    public int WaveCount {  get { return waveCount; } }

}
