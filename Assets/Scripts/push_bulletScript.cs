using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push_bulletScript : MonoBehaviour
{
    public float power;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 direction = collision.transform.position - transform.position;
            rb.AddForce(direction.normalized * power, ForceMode.Impulse);
        }

    }
}
