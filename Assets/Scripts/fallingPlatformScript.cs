using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatformScript : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 originalPos;
    public GameObject platform;
    void Start()
    {
        originalPos = new Vector3(platform.transform.position.x, platform.transform.position.y, platform.transform.position.z);
        //originalPos = FindGameObjectWithTag("falling").transform.position;

        Debug.Log(originalPos);
    }

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Just waited 2 seconds");
        
        rb.isKinematic = true;
        platform.transform.position = originalPos;
        yield break;

    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("About to StartCoroutine");
        Invoke("drop", 0.7f);
        //StartCoroutine(TestCoroutine());
        Debug.Log("Back from StartCoroutine");
        //ield return new WaitForSeconds(3);

    }


    void drop()
    {
        rb.isKinematic = false;
        StartCoroutine(TestCoroutine());

    }
}
