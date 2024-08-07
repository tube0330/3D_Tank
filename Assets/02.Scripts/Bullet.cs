using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform tr;
    public Rigidbody rb;
    public TrailRenderer trailRenderer;
    public CapsuleCollider col;
    float speed = 1000f; // 총알 속도

    void Awake()
    {
        tr = transform;
        rb = GetComponent<Rigidbody>();
        trailRenderer = GetComponent<TrailRenderer>();
        col = GetComponent<CapsuleCollider>();
        rb.AddForce(tr.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ExplosionCannon(3.0f));
    }

    private void OnDisable()
    {
        trailRenderer.Clear();
        tr.position = Vector3.zero;
        tr.rotation = Quaternion.identity;
        rb.Sleep();
    }

    IEnumerator ExplosionCannon(float time)
    {
        yield return new WaitForSeconds(time);
        col.enabled = false;
        GameObject eff = Instantiate(Resources.Load<GameObject>("BigExplosionEffect"), tr.position, Quaternion.identity);
        Destroy(eff, 1.0f);
        Destroy(this.gameObject, 1.0f);
    }
}
