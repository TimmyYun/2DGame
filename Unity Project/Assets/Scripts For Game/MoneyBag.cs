using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyBag : MonoBehaviour
{
    public TMP_Text text;

    public void SetMaxMoney(int maxMoney)
    {
        text.text = "0/" + maxMoney;
    }

    public void SetMoney(int CurrentMoney, int MaxMoney)
    {
        if(CurrentMoney <= MaxMoney)
        {
            text.text = CurrentMoney + "/" + MaxMoney;
        }
    }
}
