using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceSound : MonoBehaviour
{
    public AudioSource sound;


    private void OnTriggerExit(Collider other)
    {
        sound.Play();
    }
}
