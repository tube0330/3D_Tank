using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_LaserBeam : MonoBehaviour
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
        lineRenderer.SetPosition(0, tr.InverseTransformPoint(ray.origin));  // 레이의 시작점을 오브젝트의 로컬 좌표계로 변환하고 LineRenderer의 시작점을 레이의 시작점으로 설정

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 2000f, Color.red);

        if (Physics.Raycast(ray, out hit, 2000f))
            lineRenderer.SetPosition(1, tr.InverseTransformPoint(hit.point));

        else
            lineRenderer.SetPosition(1, tr.InverseTransformPoint(ray.GetPoint(200f)));  //Ray의 최대 길이인 200 유닛 지점을 LineRenderer의 끝점으로 설정. 충돌 지점이 없으므로 예비 지점을 사용

        StartCoroutine(ShowLaserBeam());
    }

    IEnumerator ShowLaserBeam()
    {
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        lineRenderer.enabled = false;
    }
}
