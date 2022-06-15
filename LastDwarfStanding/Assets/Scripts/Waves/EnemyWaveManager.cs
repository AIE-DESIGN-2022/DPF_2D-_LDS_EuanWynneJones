using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class EnemyWaveManager : MonoBehaviour
{

    public bool waveStarted = false;
    public float waveTimer = 0f;
    public float waveTimeLimit = 10f;
    public float waveBreakTimer = 0f;
    public float waveBreakTimeLimit = 5f;
    private Animator waveAnimation;



    public int waveCount;
    public Text waveTextNumber;

    // Start is called before the first frame update
    void Start()


    {
        waveAnimation = gameObject.GetComponent<Animator>();
        waveBreakTimer += Time.deltaTime;
        waveCount = 0;
        WaveBreak();
    }

    // Update is called once per frame
    void Update()
    {
        if (!waveStarted)
        {
            WaveBreak();

        }
        else
        {
            Wave();
        }
    }

    public void Wave()
    {
        waveStarted = true;
        waveTimer += Time.deltaTime;
        

        if (waveTimer >= waveTimeLimit)
        {
            waveStarted = false;

            waveBreakTimer = 0f;
            WaveBreak();

        }


    }
    public void WaveBreak()
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
    }

    public void UpdateWaveText()
    {
        waveTextNumber.text = waveCount.ToString();
    }
}
