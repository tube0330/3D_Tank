using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailCtrl : MonoBehaviour
{
    public float rotSpeed = 4000f;
    Transform tr;

    void Start()
    {
        tr = transform;    
    }

    // Update is called once per frame
    void Update()
    {
        tr.Rotate(Vector3.right * rotSpeed * Time.deltaTime);
    }
}
