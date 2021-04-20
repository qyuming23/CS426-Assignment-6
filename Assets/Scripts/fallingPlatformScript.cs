using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatformScript : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 originalPos;
    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    IEnumerator TestCoroutine()
    {
        Debug.Log("about to yield return WaitForSeconds(1)");
        yield return new WaitForSeconds(2);
        Debug.Log("Just waited 1 second");
        gameObject.transform.position = originalPos;
        rb.isKinematic = true;
        Debug.Log("Just waited another second");
        yield break;
        Debug.Log("You'll never see this"); // produces a dead code warning
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
        //StartCoroutine(TestCoroutine());

    }
}
