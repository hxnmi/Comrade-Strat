using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement")] 
    private Vector3 moveDir;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    [Header("Jump")] 
    public float jumpSpeed;

    public float gravity;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if(controller.isGrounded)
        {
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; 
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); 
                transform.rotation = Quaternion.Euler(0f, angle, 0f); 
                moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                if(Input.GetButtonDown("Jump"))
                {
                    Debug.Log("can jump");
                    moveDir.y = jumpSpeed;
                    Debug.Log(moveDir);
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("can jump");
                moveDir.y = jumpSpeed;
                Debug.Log(moveDir);
            }
        }
        
        moveDir.y += gravity * Time.deltaTime;
        controller.Move(moveDir.normalized * (speed * Time.deltaTime));
    }

    private void OnApplicationFocus(bool focusStatus) 
    {
        if(focusStatus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
