using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    Transform tr;
    Rigidbody rb;
    public float moveSpeed = 10f;
    float rotSpeed = 50f;
    float h , v, r;

    void Start()
    {
        tr = transform;
        rb = GetComponent<Rigidbody>();
        h = v = r = 0f;
    }

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 moveVector = v * Vector3.forward;
        tr.Translate(moveVector.normalized * moveSpeed * Time.deltaTime);
    
        tr.Rotate(Vector3.up * h * Time.deltaTime * rotSpeed);
    }
}