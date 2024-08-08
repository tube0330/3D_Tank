using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    Transform tr;
    LineRenderer lineRenderer;

    void Start()
    {
        tr = transform;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = false; //로컬좌표로 하기 위해
    }

    public void FireRay()
    {
        Ray ray = new Ray(tr.position, tr.forward);
        lineRenderer.SetPosition(0, tr.InverseTransformPoint(ray.origin));

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 2000f, Color.red);

        if (Physics.Raycast(ray, out hit, 2000f))
            lineRenderer.SetPosition(1, tr.InverseTransformPoint(hit.point));

        else
            lineRenderer.SetPosition(1, tr.InverseTransformPoint(ray.GetPoint(200f)));

        StartCoroutine(ShowLaserBeam());
    }

    IEnumerator ShowLaserBeam()
    {
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        lineRenderer.enabled = false;
    }
}
