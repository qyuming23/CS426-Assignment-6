using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportBullet : MonoBehaviour
{
    public GameObject teleportTarget;
    public GameObject player;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("teleport", 0f);

        }
    }

    void teleport()
    {
        player.transform.position = teleportTarget.transform.position;

        Debug.Log("Teleport Activated");


    }

}
