using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CurrencyManager : MonoBehaviour
{
    public int currentCurrencyAmount;
    public Text currencyAmountText;


    // Start is called before the first frame update
    void Start()
    {
        UpdateCurrencyText();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void UpdateCurrencyText()
    {
        currencyAmountText.text = currentCurrencyAmount.ToString();
    }
    public void AddCurrency(int _currencyToAdd)
    {
        //add currency amount from pickup item to total currencycount
        currentCurrencyAmount += _currencyToAdd;
        //call the function to update the text to match current currency amount
        UpdateCurrencyText();
    }
    public void RemoveCurrency(int _currencyToRemove)
    {
        //Remove currency amount from total
        currentCurrencyAmount -= _currencyToRemove;
        UpdateCurrencyText();
    }
}