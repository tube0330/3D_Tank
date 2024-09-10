using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Bullet : MonoBehaviour
{
    Rigidbody rb;
    float speed = 1000f;
    CapsuleCollider col;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
        col = GetComponent<CapsuleCollider>();
    }

    void OnTriggerEnter(Collider col)
    {
        StartCoroutine(Explosion(0.5f));

    }

    IEnumerator Explosion(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject eff = Instantiate(Resources.Load<GameObject>("BigExplosionEffect"), transform.position, Quaternion.identity);
        //col.enabled = false;
        Destroy(eff, 1.0f);
        Destroy(this.gameObject, 1.0f);
    }
}
