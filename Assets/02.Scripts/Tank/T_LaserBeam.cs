using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_LaserBeam : MonoBehaviour
{
    Transform tr;
    LineRenderer line;

    void Start()
    {
        tr = transform;
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        line.useWorldSpace = false;
    }

    public void FireRay()
    {
        Ray ray = new Ray(tr.position, tr.forward);
        
    }
}
