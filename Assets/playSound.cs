using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    public AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        sound.Play();
    }

    private void OnTriggerExit(Collider other)
    {

        sound.Stop();
    }
}
