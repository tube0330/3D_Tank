using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheCtrl : MonoBehaviour
{
    Transform tr;
    public float movespeed = 0f;
    public float rotSpeed = 0f;
    public float verticalSpeed = 0f;

    void Start()
    {
        tr = transform;
    }

    void Update()
    {
        #region Apache A, D 좌우회전
        if (Input.GetKey(KeyCode.A))    //눌렀을 때
            rotSpeed += -0.05f;               //rotSpeed value minus --1

        else if (Input.GetKey(KeyCode.D))
            rotSpeed += 0.05f;               //rotSpeed value plus --2

        else    //누르지 않았을 때
        {
            if (rotSpeed > 0f) rotSpeed += -0.05f;
            else if (rotSpeed < 0f) rotSpeed += 0.05f;      //rotSpeed value minus -> plus --1
        }

        tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime);  //rotSpeed value plus -> minus --2
        #endregion

        #region Apache W, S 앞뒤 이동
        if (Input.GetKey(KeyCode.W))
            movespeed += 0.02f;

        else if (Input.GetKey(KeyCode.S))
            movespeed += -0.02f;

        else
        {
            if (movespeed > 0f) movespeed += -0.02f;
            else if (movespeed < 0f) movespeed += 0.02f;
        }

        tr.Translate(Vector3.forward * movespeed * Time.deltaTime, Space.Self);
        #endregion

        #region Apache Z, C 위아래 이동
        if (Input.GetKey(KeyCode.Z)) //up
            verticalSpeed += 0.02f;

        else if (Input.GetKey(KeyCode.C))
            verticalSpeed += -0.02f;

        else
        {
            if (verticalSpeed > 0f) verticalSpeed += -0.02f;
            else if (verticalSpeed < 0f) verticalSpeed += 0.02f;
        }
        tr.Translate(Vector3.up * verticalSpeed * Time.deltaTime, Space.World);
        #endregion
    }
}
