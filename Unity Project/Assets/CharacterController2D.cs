using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 200f;
    [SerializeField] private bool isOnTheHorse = true;
    [SerializeField] private LayerMask WhatIsGround;
    [SerializeField] private Transform GroundCheck;




    private Rigidbody2D CharacterRigidbody2D;
    private bool CharacterFacingRight = false;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
