using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playsound3 : MonoBehaviour
{
    public AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        sound.Play();
    }

}
