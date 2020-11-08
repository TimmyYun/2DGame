using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScpirt : MonoBehaviour
{
    public float rotationspeed=20f;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = 20f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.rotation > 360)
        {
            rb.rotation = 0;
        }
        rb.rotation += 5f;
    }
}
