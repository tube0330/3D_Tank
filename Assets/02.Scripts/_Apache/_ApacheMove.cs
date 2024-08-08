using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheMove : MonoBehaviour
{
    float h, v;
    float moveSpeed = 60f;
    float rotSpeed = 30f;
    Transform tr;
    PlayerMove player;
    public RideApache rideApache;
    public bool isGround = false;

    void Start()
    {
        tr = transform;
        h = v = 0f;
        player = GetComponent<PlayerMove>();
        rideApache = transform.GetChild(3).GetComponent<RideApache>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (gameObject.CompareTag("TERRAIN"))
            {
                Debug.Log("땅");
                isGround = true;}
    }

    void FixedUpdate()
    {
        if (rideApache.isRide)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            Vector3 moveVector = v * Vector3.forward;
            tr.Translate(moveVector.normalized * moveSpeed * Time.deltaTime);

            tr.Rotate(Vector3.up * h * Time.deltaTime * rotSpeed);

            //Z -> up
            if (Input.GetKey(KeyCode.Z))
            {
                tr.Translate(Vector3.up * Time.deltaTime * 10f);
            }

            //C -> down
            else if (Input.GetKey(KeyCode.C))
            {
                tr.Translate(Vector3.down * Time.deltaTime * 10f);
            }
        }
    }
}
