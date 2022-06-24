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

    //public int costOfFarm;
    //public int currentCostOfFarm;

    public int currentIncome;

    public GameObject UnbuiltFarm;
    public GameObject BuiltFarm;
    [SerializeField] private FarmUpgradeManagerUI farmUpgradeManagerUI;

    public Text costOfFarmText;
    public Text CostOfFarmUpgradeText;

    public int currencyCostFarm = 1;
    public int CurrentCurrencyCostFarm = 1;

    public int currencyCostFarmUpgrade = 1;
    public int CurrentCurrencyCostFarmUpgrade = 1;

    public bool IsFarmBought;


    public CurrencyManager currencyManager;
    void Start()
    {


        UpdateFarmUpgradeCost();
        UpdateBuyFarmCost();

        IsFarmBought = false;


        farmColider.SetActive(true);
        BuiltFarm.SetActive(false);
        farmIncomeTimer += Time.deltaTime;
        currencyManager = FindObjectOfType<CurrencyManager>();
        if (farmUpgradeManagerUI == null)
        {
            farmUpgradeManagerUI = FindObjectOfType<FarmUpgradeManagerUI>();

        }



    }

    // Update is called once per frame
    void Update()
    {
        if (IsFarmBought)
        {
            farmIncomeTimer += Time.deltaTime;
            PassiveIncomeOverTime();

        }
    }

    public void BuyPassiveIncomeFarm()
    {
        if (currencyManager.currentCurrencyAmount >= currencyCostFarm)
        {
            IsFarmBought = true;
            currencyManager.RemoveCurrency(currencyCostFarm);
            currencyManager.UpdateCurrencyText();

            // currencyManager.UpdateCurrencyText();

            //farmColider.SetActive(false);
            BuiltFarm.SetActive(true);
            currentIncome += 5;

            farmUpgradeManagerUI.BuyFarmButton.SetActive(false);
            farmUpgradeManagerUI.UpgradeFarmButton.SetActive(true);
        }
        else
        {
            return;
        }
    }

    public void UpgradePassiveIncomeFarm()
    {
        if (currencyManager.currentCurrencyAmount >= currencyCostFarmUpgrade)
        {
            currencyManager.RemoveCurrency(currencyCostFarmUpgrade);
            //currencyManager.UpdateCurrencyText();
            currencyCostFarmUpgrade += currencyCostFarmUpgrade + 6;
            UpdateFarmUpgradeCost();
            currentIncome += (currentIncome + 5 / 3);

        }

    }

    /*  public void UIToggle()
      {
          farmUpgradeManagerUI.FarmMenuToggle();

      }*/

    public FarmUpgradeManagerUI farmUpgradeUI
    {
        get { return farmUpgradeManagerUI; }

    }


    public void UpdateFarmUpgradeCost()
    {

        CostOfFarmUpgradeText.text = currencyCostFarmUpgrade.ToString();
    }

    public void UpdateBuyFarmCost()
    {

        costOfFarmText.text = currencyCostFarm.ToString();
    }

    public void PassiveIncomeOverTime()
    {
        if (farmIncomeTimer > IncomeInterval)
        {
            farmIncomeTimer = 0;
            currencyManager.currentCurrencyAmount += currentIncome;
            currencyManager.UpdateCurrencyText();

        }
    }
}
