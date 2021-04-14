using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportScript : MonoBehaviour
{
    public GameObject teleportTarget;
    public GameObject player;
    public AudioSource sound;
    public AudioSource sound2;
    public AudioSource sound3;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = teleportTarget.transform.position;
            sound.Play();
            Debug.Log("Teleport Activated");
            sound2.Stop();
            sound3.Play();
        }
    }

}
