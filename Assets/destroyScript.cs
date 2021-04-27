using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyScript : MonoBehaviour
{
    GameObject bullet;

    void Start()
    {
        StartCoroutine("WaitAndDestroy");
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
