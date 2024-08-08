using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApachePatrol : MonoBehaviour
{
    #region 나
    /*public List<Transform> patrolPoints = new List<Transform>();
    float patrolSpeed = 30f;
    float damping = 0.5f;
    public int nextPoint = 0;
    public bool isRotate = false;

    Transform tr;

    void Start()
    {
        var point = GameObject.Find("PatrolPoint");

        if(point != null)
        point.GetComponentsInChildren<Transform>(patrolPoints);
        patrolPoints.RemoveAt(0);

        nextPoint = Random.Range(0, patrolPoints.Count);
        tr = transform;
        //StartCoroutine(MovePoint());
    }

    void Update()
    {
        Vector3 direction = patrolPoints[nextPoint].position - tr.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(tr.rotation, lookRotation, Time.deltaTime * damping);

        direction.Normalize();

        tr.position += direction * patrolSpeed * Time.deltaTime;
        
        float distance = Vector3.Distance(tr.position, patrolPoints[nextPoint].position);

        if(distance < 1.0f)
        {
            nextPoint = Random.Range(0, patrolPoints.Count);
        }
    }*/
    #endregion

    #region ?
    public List<Transform> patrolList = new List<Transform>();
    Transform tr = null;
    public bool isSearch = true;
    float moveSpeed = 100f;
    int wayPointCount;
    float rotSpeed = 15f;
    public Transform firePos1;
    public Transform firePos2;
    public GameObject A_Bullet;
    float curDelay = 0f;
    float maxDelay = 5f;

    void Start()
    {
        var point = GameObject.Find("PatrolPoint");

        if (point != null)
            point.GetComponentsInChildren<Transform>(patrolList);
        patrolList.RemoveAt(0);

        wayPointCount = 0;
        tr = transform;

        A_Bullet = Resources.Load<GameObject>("A_Bullet");
        curDelay = maxDelay;
    }

    void Update()
    {
        if (isSearch)
            MovePoint();

        else Attack();
    }

    void MovePoint()
    {
        Vector3 pointDist = Vector3.zero;
        float dist = 0f;

        if (wayPointCount == 0)
        {
            pointDist = patrolList[0].position - transform.position;
            tr.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pointDist), Time.deltaTime * rotSpeed);
            tr.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            dist = Vector3.Distance(transform.position, patrolList[0].position);
            if (dist <= 10f) wayPointCount = 1;
        }

        else if (wayPointCount == 1)
        {
            pointDist = patrolList[1].position - transform.position;
            tr.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pointDist), Time.deltaTime * rotSpeed);
            tr.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            dist = Vector3.Distance(transform.position, patrolList[1].position);
            if (dist <= 10f) wayPointCount = 2;
        }

        else if (wayPointCount == 2)
        {
            pointDist = patrolList[2].position - transform.position;
            tr.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pointDist), Time.deltaTime * rotSpeed);
            tr.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            dist = Vector3.Distance(transform.position, patrolList[2].position);
            if (dist <= 10f) wayPointCount = 3;
        }

        else if (wayPointCount == 3)
        {
            pointDist = patrolList[3].position - transform.position;
            tr.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pointDist), Time.deltaTime * rotSpeed);
            tr.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            dist = Vector3.Distance(transform.position, patrolList[3].position);
            if (dist <= 10f) wayPointCount = 0;
        }

        Search();
    }

    void Search()
    {
        float FindTankDist = (GameObject.FindWithTag("Player").transform.position - tr.position).magnitude;

        if (FindTankDist <= 75f)
            isSearch = false;
    }

    void Attack()
    {
        Vector3 targetDist = GameObject.FindWithTag("Player").transform.position - tr.position;
        tr.rotation = Quaternion.Slerp(tr.rotation, Quaternion.LookRotation(targetDist), Time.deltaTime * rotSpeed);

        if (targetDist.magnitude > 75f)
            isSearch = true;

        curDelay -= 0.02f;

        if (curDelay <= 0f)
        {
            curDelay = maxDelay;

            Fire();
        }
    }

    void Fire()
    {
        Instantiate(A_Bullet, firePos1.position, firePos1.rotation);
        Instantiate(A_Bullet, firePos2.position, firePos2.rotation);
    }
    #endregion
}
