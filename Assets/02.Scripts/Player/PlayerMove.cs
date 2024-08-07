using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform tr;
    Camera cam;
    float h, v = 0f;
    float speed = 5f;

    void Start()
    {
        tr = transform;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        cam = this.gameObject.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        tr.Translate(h * speed * Vector3.right * Time.deltaTime);
        tr.Translate(v * speed * Vector3.up * Time.deltaTime);


    }
}
