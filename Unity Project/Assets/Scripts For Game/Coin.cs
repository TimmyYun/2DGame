using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value=1;
    PlayerAttributes player;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        player = hitInfo.GetComponent<PlayerAttributes>();
        if(player != null)
        {
            player.GetCoin(value);
        }
        Destroy(gameObject);
    }
}
