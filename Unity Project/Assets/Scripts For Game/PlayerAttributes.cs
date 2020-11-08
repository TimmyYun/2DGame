using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 100;
    [SerializeField] public int CurrentHealth;
    [SerializeField] public int MaxMoney = 20;
    [SerializeField] public int CurrentMoney = 0;
    [SerializeField] public bool isOnCampfire = false;
    [SerializeField] private Transform BuildCheck;

    public HealthBarScript healthBar;
    public MoneyBag moneyBag;
    public Campfire campfire;

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
        if (isOnCampfire == true && campfire.isBuilt == false)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                buildStructure();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }

    }

    public void buildStructure()
    {
        GetCoin(-1);
        campfire.BuildOneStage();
    }

    public void GetCoin(int value)
    {
        if (CurrentMoney < MaxMoney)
        {
            CurrentMoney += value;
            moneyBag.SetMoney(CurrentMoney, MaxMoney);
        }
    }

    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        healthBar.SetHealth(CurrentHealth);
    }
}
