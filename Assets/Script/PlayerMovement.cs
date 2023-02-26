using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private float movementX;
    private float movementZ;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movementX = Input.GetAxis("Horizontal");
        movementZ = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(movementX, 0, movementZ ) * speed;
    }
}
