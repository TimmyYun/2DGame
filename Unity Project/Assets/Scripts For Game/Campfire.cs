using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public GameObject Interface;
    public GameObject Wheel1;
    public GameObject Wheel2;
    public GameObject Wheel3;
    public GameObject NextBuilding;
    public GameObject CampfireSprite;

    public Transform CampfirePoint;
    public Transform CampfireBottomMid;
    public float CampfireRange = 1f;
    public LayerMask PlayerLayer;
    public float showInterfaceTime = 0.5f;
    float nextshow = 0;
    public bool isBuilt = false;
    private int stagesofbuild = 0;
    public int maxstagesofbuild = 3;
    private int numberofplayers = 0;

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(CampfirePoint.position, CampfireRange);
    }
    void Start()
    {
        if (stagesofbuild == 0)
        {
            Wheel1.SetActive(true);
            Wheel2.SetActive(true);
        }
    }
    void Update()
    {

        if (isBuilt == false)
        {
            if (Time.time >= nextshow)
            {

                Interface.SetActive(false);
                Collider2D[] hitObjects = Physics2D.OverlapCircleAll(CampfirePoint.position, CampfireRange, PlayerLayer);
                foreach (Collider2D Player in hitObjects)
                {
                    Interface.SetActive(true);

                    nextshow = Time.time + showInterfaceTime;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(CampfirePoint.position, CampfireRange, PlayerLayer);
            foreach (Collider2D Player in hitObjects)
            {
                numberofplayers++;
                if (numberofplayers == 1)
                {
                    if (Player.GetComponent<PlayerAttributes>().GetCurrentMoney() > 0)
                    {
                        Player.GetComponent<PlayerAttributes>().GetCoin(-1);
                        buildStructure();
                    }
                }
            }
            numberofplayers = 0;
        }
    }

    public void buildStructure()
    {
        if (isBuilt == false)
        {
            BuildOneStage();
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
            Instantiate(NextBuilding, CampfireBottomMid.position, CampfirePoint.rotation);
            Instantiate(CampfireSprite, new Vector3(CampfireBottomMid.position.x + 20, CampfireBottomMid.position.y, CampfireBottomMid.position.z), CampfirePoint.rotation);

            DestroyCampfire();
        }
    }

    public void DestroyCampfire()
    {
        Destroy(gameObject);
    }
}

