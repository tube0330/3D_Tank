using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    GameObject bulletPrefab;
    Transform tr;
    AudioSource source;
    AudioClip clip;

    void Start()
    {
        tr = transform;
        bulletPrefab = Resources.Load<GameObject>("Bullet");
        source = GetComponent<AudioSource>();
        clip = Resources.Load<AudioClip>("grenade_exp2");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, tr.position, tr.rotation);
    }
}