using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 100;
    [SerializeField] public int CurrentHealth;
    [SerializeField] public int MaxMoney = 20;
    [SerializeField] public int CurrentMoney = 0;

    public HealthBarScript healthBar;
    public MoneyBag moneyBag;
    public Transform SpawnPoint;

    public GameObject Coin;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CurrentMoney > 0 )
            {
            DropCoin();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

    }


    public int GetCurrentMoney()
    {
        return CurrentMoney;
    }

    public void GetCoin(int value)
    {
        if (value < 0)
        {
            CurrentMoney += value;
            moneyBag.SetMoney(CurrentMoney, MaxMoney);
        }
        else if (CurrentMoney < MaxMoney)
        {
            CurrentMoney += value;
            moneyBag.SetMoney(CurrentMoney, MaxMoney);
        }

    }

    public void DropCoin()
    {
        Instantiate(Coin, SpawnPoint.position, SpawnPoint.rotation);
        GetCoin(-1);
    }

    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        healthBar.SetHealth(CurrentHealth);
    }

    public bool IsFull()
    {
        if (CurrentMoney == MaxMoney)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
