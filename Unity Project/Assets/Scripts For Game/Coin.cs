using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value=1;
    PlayerAttributes player;
    public float nextpickup=0f;
    public float pickupinterval=1f;
    public float rangeofcoin = 0.5f;
    public LayerMask PlayerLayer;
    public Transform Center;
    public bool isTaken;




    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Center.position, rangeofcoin);
    }



    void Start()
    {
        isTaken = false;
        nextpickup = Time.time + pickupinterval;
    }

    void FixedUpdate()
    {
        if (Time.time > nextpickup)
        {
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(Center.position, rangeofcoin, PlayerLayer);
            foreach(Collider2D player in hitObjects)
            {
                if (!player.GetComponent<PlayerAttributes>().IsFull())
                {
                    if (isTaken == false)
                    {
                        Destroy(gameObject);

                        player.GetComponent<PlayerAttributes>().GetCoin(1);
                        nextpickup = Time.time + pickupinterval;
                        isTaken = true;
                    }
                }
            }
        }     
    }
}
