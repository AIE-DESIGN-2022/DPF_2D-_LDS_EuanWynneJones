using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerHealthManager playerHealthManager;
    public BaseHealthManager baseHealthManager;
    public PlayerWeapon playerWeapon;
    public CurrencyManager currencyManager;
    public ShieldManager shieldManager;
    public Shield shield;

    public GameObject upgrade_UI;
    public AudioSource upgrade_UIaudio;


    public Text CostBaseHealthUpgradeText;
    public Text CostBaseRepairText;


    public int currencyCostBaseHealthUpgrade = 1;
    public int currenctCurrencyCostBaseHealthUpgrade = 1;

    public int currencyCostBaseRepair = 1;
    public int currenctCurrencyCostBaseRepair = 1;

    private void Awake()
    {
        UpdateUpgradeBaseHealthCost();
        UpdateBaseRepairCost();
    }
    void Start()
    {

        upgrade_UI.SetActive(false);
        UpdateUpgradeBaseHealthCost();
        UpdateBaseRepairCost();

        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
        shieldManager = FindObjectOfType<ShieldManager>();
        baseHealthManager = FindObjectOfType<BaseHealthManager>();
        playerWeapon = FindObjectOfType<PlayerWeapon>();
        currencyManager = FindObjectOfType<CurrencyManager>();

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void BaseHealthUpgrade()
    {
        currencyCostBaseHealthUpgrade = 1 + currenctCurrencyCostBaseHealthUpgrade;

        if (currencyManager.currentCurrencyAmount >= currencyCostBaseHealthUpgrade)
        {

            currencyManager.RemoveCurrency(currencyCostBaseHealthUpgrade);
            currencyManager.UpdateCurrencyText();

            Debug.Log(baseHealthManager.maxHealth);

            baseHealthManager.maxHealth += 50f;


            baseHealthManager.UpdateBaseHealthBar();

            currenctCurrencyCostBaseHealthUpgrade += 3;
            UpdateUpgradeBaseHealthCost();
            Debug.Log(currencyCostBaseHealthUpgrade);
        }
    }

    public void BaseHealthRepair()
    {
        currencyCostBaseRepair = 1 + currenctCurrencyCostBaseRepair;

        if (currencyManager.currentCurrencyAmount >= currencyCostBaseRepair && baseHealthManager.currentHealth < baseHealthManager.maxHealth)
        {

            currencyManager.RemoveCurrency(currencyCostBaseRepair);
            currencyManager.UpdateCurrencyText();

            baseHealthManager.currentHealth = baseHealthManager.maxHealth;
            baseHealthManager.UpdateBaseHealthBar();
            currenctCurrencyCostBaseRepair += 2;

            UpdateBaseRepairCost();

            Debug.Log(currencyCostBaseRepair);
        }
    }

    public void BaseTurretInnitial()
    {

    }

    public void BaseTurretUpgrade()
    {

    }



    public void PlayerDamageUpgrade()
    {
        playerWeapon.damage += 10;
    }
    public void PlayerShieldUpgrade()
    {
        shield.maxShield += 50;
        shieldManager.UpdateShieldBar();
    }




    public void UpgradeMenuToggle()
    {
       
        if (upgrade_UI.activeInHierarchy)
        {
            ResumeLevelUpgrade();
        }
        else
        {
            PauseLevelUpgrade();
        }
        if (upgrade_UIaudio != null) upgrade_UIaudio.Play();
        else Debug.LogError("respawn_UIaudio not found");
    }

    public void ResumeLevelUpgrade()
    {
        upgrade_UI.SetActive(false);
    }

    public void PauseLevelUpgrade()
    {
        upgrade_UI.SetActive(true);
    }


    public void UpdateUpgradeBaseHealthCost()
    {
        CostBaseHealthUpgradeText.text = currenctCurrencyCostBaseHealthUpgrade.ToString();
    }

    public void UpdateBaseRepairCost()
    {

        CostBaseRepairText.text = currenctCurrencyCostBaseRepair.ToString();
    }
}