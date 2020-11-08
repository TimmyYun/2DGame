using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public GameObject Interface;
    public GameObject Wheel1;
    public GameObject Wheel2;
    public GameObject Wheel3;

    public Transform CampfirePoint;
    public float CampfireRange = 1f;
    public LayerMask PlayerLayer;
    public float showInterfaceTime = 0.5f;
    float nextshow = 0;
    public bool isBuilt = false;
    public int stagesofbuild = 0;
    public int maxstagesofbuild = 3;

    public PlayerAttributes player;

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(CampfirePoint.position, CampfireRange);
    }

    void Update()
    {
        if (isBuilt == false)
        {
            if (Time.time >= nextshow)
            {
                Interface.SetActive(false);
                player.isOnCampfire = false;
            }
            if (Time.time >= nextshow)
            {
                Collider2D[] hitObjects = Physics2D.OverlapCircleAll(CampfirePoint.position, CampfireRange, PlayerLayer);
                foreach (Collider2D Player in hitObjects)
                {
                    Interface.SetActive(true);
                    player.isOnCampfire = true;
                    nextshow = Time.time + showInterfaceTime;
                }
            }
        }
    }

    public void BuildOneStage()
    {
        stagesofbuild = stagesofbuild + 1;
        if (stagesofbuild == 1)
        {
            Wheel1.SetActive(false);
        }
        if (stagesofbuild == 2)
        {
            Wheel2.SetActive(false);
        }
        if (stagesofbuild == maxstagesofbuild)
        {
            isBuilt = true;
            DestroyCampfire();
        }
    }

    public void DestroyCampfire()
    {
        Destroy(gameObject);
    }
}

