using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCtrl : MonoBehaviour
{
    Transform tr;
    public float rotSpeed = 1500f;
    public float upperAngleLimit = 10f;
    public float lowerAngleLimit = -20f;
    public float curRotAngle = 0f;

    void Start()
    {
        tr = transform;
    }

    void Update()
    {
        float wheel = -Input.GetAxis("Mouse ScrollWheel");  //음수 값은 위로 스크롤, 양수 값은 아래로 스크롤
        float angle = wheel * rotSpeed * Time.deltaTime;

        curRotAngle += angle;
        curRotAngle = Mathf.Clamp(curRotAngle, lowerAngleLimit, upperAngleLimit);
        tr.localEulerAngles = new Vector3(curRotAngle, 0f, 0f); 
    }
}
