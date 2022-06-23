using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveIncomeFarmManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject farmColider;
    public float farmIncomeTimer;
    public float IncomeInterval = 10f;

    public int costOfFarm;
    public int currentCostofFarm;

    public int CurrentIncome;

    public Image UnbuiltFarm;
    public Image BuiltFarm;


    public CurrencyManager currencyManager;
    void Start()
    {

        farmColider.SetActive(true);
        farmIncomeTimer +=Time.deltaTime;
        currencyManager = FindObjectOfType<CurrencyManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyPassiveIncomeFarm()
    {
        if(currencyManager.currentCurrencyAmount >= costOfFarm)
        {
           farmColider.SetActive(false);
        }
    }
}
