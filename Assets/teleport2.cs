using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport2 : MonoBehaviour
{
    public GameObject teleportTarget;
    public GameObject player;
    public AudioSource sound;


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Just waited 1 second");
    }

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
        sound.Play();
        Debug.Log("Teleport Activated");
    }


}
