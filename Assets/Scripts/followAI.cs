using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followAI : MonoBehaviour
{
    public Transform target;
    NavMeshAgent nav;
    public Transform teleportTarget;
    public GameObject player;
   // public AudioSource warningSound;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.position); 
    }

    void OnTriggerEnter(Collider other)
    {
        player.transform.position = teleportTarget.transform.position;
        Debug.Log("trigger");
    }

    void OnTriggerExit(Collider other)
    {
      ///  warningSound.Stop();
    }
}
