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

    public AudioSource jumpSound;

    private float dashTime = .30f;

    private float dashSpeed = 20;

    private Vector3 moveDir;

    public bool isDashing;

    private int dashAttempts;

    private float dashStarttime;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        jumpSound = GetComponent<AudioSource>();
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
        moveDir = new Vector3(horizontal, 0f, vertical).normalized;

        if(controller.isGrounded){
            canDoubleJump = true;
            if(Input.GetButtonDown("Jump")){
                directionY = jumpspeed;
                jumpSound.Play();
            }
        }
        else{
            if(Input.GetButtonDown("Jump")){
                directionY = jumpspeed * doubleJumpMultiplier;
                canDoubleJump = false;
                jumpSound.Play();
                jumpSound.Play();
            }
        }

        if(direction.magnitude >= 0.1f){
            moveDir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }


        if(!controller.isGrounded){
          directionY -= gravity * Time.deltaTime;      
        }
        
        moveDir.y = directionY;
            
        controller.Move(moveDir * speed * Time.deltaTime);

        HandleDash();
    }

    void HandleDash(){
        bool isTryingtoDash = Input.GetKeyDown(KeyCode.F);

        if(isTryingtoDash && !isDashing){
            if(dashAttempts <= 50){
                startDash();
            }
        }
        
        if(isDashing){
            if(Time.time - dashStarttime <= 0.4f){
                controller.Move(transform.forward * 30f * Time.deltaTime);
            }
            else{
                endDash();
            }
        }
    }

    void startDash(){
        isDashing = true;
        dashStarttime = Time.time;
        dashAttempts += 1;
    }

    void endDash(){
        isDashing = false;
        dashStarttime = 0;

    }
}
