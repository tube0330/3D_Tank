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
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            StartCoroutine(ExplosionCannon(3.0f));
        }

        else
            StartCoroutine(ExplosionCannon(3.0f));

    }

    IEnumerator ExplosionCannon(float time)
    {
        yield return new WaitForSeconds(time);
        col.enabled = false;
        GameObject eff = Instantiate(Resources.Load<GameObject>("BigExplosionEffect"), transform.position, Quaternion.identity);
        Destroy(eff, 1.0f);
        Destroy(this.gameObject, 1.0f);
    }
}
