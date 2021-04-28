using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportBullet1 : MonoBehaviour
{
    public GameObject teleportTarget;
    public GameObject platform1;
    public GameObject platform2;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            platform1.SetActive(false);
            platform2.SetActive(false);

        }
    }

   

}
