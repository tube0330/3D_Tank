using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheRay : MonoBehaviour
{
    Transform tr;
    LineRenderer lineRenderer;

    void Start()
    {
        tr = transform;
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 2000f, Color.red);

        if (Physics.Raycast(ray, out hit, 2000f))
        {
            if(hit.collider.CompareTag("Player"))
            {
                Debug.Log("Tank Detected");
            }
        }

    }
}
