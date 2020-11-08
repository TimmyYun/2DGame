using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 100;
    [SerializeField] public int CurrentHealth;
    [SerializeField] public int MaxMoney = 20;
    [SerializeField] public int CurrentMoney = 0;

    public HealthBarScript healthBar;
    public MoneyBag moneyBag;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        moneyBag.SetMaxMoney(MaxMoney);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
            GetCoin(1);
        }

    }

    void GetCoin(int value)
    {
        CurrentMoney += value;
        moneyBag.SetMoney(CurrentMoney);
    }

    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        healthBar.SetHealth(CurrentHealth);
    }
}
