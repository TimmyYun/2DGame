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
    [SerializeField] public bool isOnCampfire = false;

    public Transform buildCheck;
    public float buildrange = 1f;
    public LayerMask CampfireLayer;
    public HealthBarScript healthBar;
    public MoneyBag moneyBag;
    public float nextcampfirecheck = 0f;
    public float nextcampinterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        moneyBag.SetMaxMoney(MaxMoney);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(buildCheck.position, buildrange);
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextcampfirecheck)
        {

            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(buildCheck.position, buildrange, CampfireLayer);
            foreach (Collider2D Campfire in hitObjects)
            {
                isOnCampfire = true;
                nextcampfirecheck = Time.time + nextcampinterval;
            }
        }

            if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }

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
