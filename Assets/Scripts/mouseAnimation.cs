using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseAnimation : MonoBehaviour
{
    public Animator controller;
    public AudioSource sound;

    void Start()
    {
        controller = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
  
         controller.SetTrigger("trigger");
         sound.Play();
    }

    private void OnTriggerExit(Collider other)
    {

        controller.SetTrigger("trigger");
    }
}
