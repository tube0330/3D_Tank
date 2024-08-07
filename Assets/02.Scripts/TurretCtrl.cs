using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCtrl : MonoBehaviour
{
    Transform tr;
    float rotSpeed = 5f;

    void Start()
    {
        tr = transform;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //카메라에서 마우스 포지션 방향으로 광선 발사
        /*화면상의 2차원 좌표를 3차원 세계 좌표의 광선으로 변환하는 과정*/

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2000f, 1 << 8))
        {
            Vector3 relative = tr.InverseTransformPoint(hit.point); //맞았던 월드 위치를 탱크에 맞는 로컬좌표로 바꿈

            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg; //atan2() 함수를 이용해 두 점 간의 각도를 구함. 라디언각도를 일반각도로 바꿈

            tr.Rotate(0f, angle * Time.deltaTime * rotSpeed, 0f); //회전
        }

    }
}
