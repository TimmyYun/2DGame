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
    public Transform buildCheck;
    public float buildRange = 1f;
    public LayerMask CampfireLayer;

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(buildCheck.position, buildRange);
    }
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
        }
        
    }


    public int GetCurrentMoney()
    {
        return CurrentMoney;
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
