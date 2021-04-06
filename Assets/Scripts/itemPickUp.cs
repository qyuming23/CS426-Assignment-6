using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickUp : MonoBehaviour
{
    void onTriggerEnter(Collider collider){
        Destroy(gameObject);
    }
}
