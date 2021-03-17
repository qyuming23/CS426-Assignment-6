using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;

    private Vector3 cameraoffset;

    [Range(0.01f, 1.0f)]
    public float smoothfactor = 0.5f;
    
    public bool lookatplayer = false;

    public bool rotatearoundplayer = true;
    
    public float rotationspeed = 0.5f;

    void Start()
    {
        cameraoffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(rotatearoundplayer){
            Quaternion camturnangle =  Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationspeed, Vector3.up);
            cameraoffset = camturnangle * cameraoffset;
        }

        Vector3 newPos = playerTransform.position + cameraoffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothfactor);

        if(lookatplayer){
            transform.LookAt(playerTransform);
        }
    }
}
