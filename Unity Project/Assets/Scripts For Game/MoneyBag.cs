using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class MoneyBag : MonoBehaviour
{
    public Text text;

    void SetMaxMoney(int maxMoney)
    {
        text.text = "0/" + maxMoney;
    }

    void SetMoney(int CurrentMoney, int MaxMoney)
    {
        text.text = CurrentMoney + "/" + MaxMoney;
    }
}
