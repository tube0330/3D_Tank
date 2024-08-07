using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideApache : MonoBehaviour
{
    string playerTag = "Player";
    public bool isRide = false;
    public GameObject player;
    public Camera cam;
    public Transform takeoffTr;
    public ApacheMove apacheMove;

    void Start()
    {
        player = GameObject.FindWithTag(playerTag);
        cam = Camera.main;
        takeoffTr = GameObject.Find("Apache").transform.GetChild(4).GetComponent<Transform>();
        apacheMove = GameObject.Find("Apache").GetComponent<ApacheMove>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag(playerTag))
            OnApache();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isRide)
            OffApache();
    }

    public void OnApache()
    {
        isRide = true;
        player.SetActive(false);
        cam.depth = 0;
        player.transform.GetChild(0).GetComponent<Camera>().depth = -1;
        AudioListener listener = cam.GetComponent<AudioListener>();
        listener.enabled = true;
    }

    public void OffApache()
    {
        if (apacheMove.isGround)
        {
            isRide = false;
            player.SetActive(true);
            cam.depth = 0;
            player.transform.GetChild(0).GetComponent<Camera>().depth = 1;
            AudioListener listener = cam.GetComponent<AudioListener>();
            listener.enabled = false;
            player.transform.position = takeoffTr.position;
        }
    }
}
