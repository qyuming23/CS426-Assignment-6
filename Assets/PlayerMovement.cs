using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float speed = 6f;

    public float turnsmoothtime = 0.1f;

    float turnSmoothVelocity;

    private CharacterController controller;

    public Transform cam;

    private bool canDoubleJump = false;

    private float directionY = 0;

    private float gravity = 9.81f;

    private float jumpspeed = 3.5f;

    private float doubleJumpMultiplier = 1.2f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnSmoothVelocity, turnsmoothtime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f){
            moveDir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }

        if(controller.isGrounded){
            canDoubleJump = true;
            if(Input.GetButtonDown("Jump")){
                directionY = jumpspeed;
            }
        }
        else{
            if(Input.GetButtonDown("Jump")){
                directionY = jumpspeed * doubleJumpMultiplier;
                canDoubleJump = false;
            }
        }

        if(!controller.isGrounded){
          directionY -= gravity * Time.deltaTime;      
        }
        
        moveDir.y = directionY;
            
        controller.Move(moveDir * speed * Time.deltaTime);

    }
}
