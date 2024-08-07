using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCtrl : MonoBehaviour
{
    Transform tr;
    void Start()
    {
        tr = transform;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //카메라에서 마우스 포지션 방향으로 광선 발사
        /*화면상의 2차원 좌표를 3차원 세계 좌표의 광선으로 변환하는 과정*/

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
    }
}
