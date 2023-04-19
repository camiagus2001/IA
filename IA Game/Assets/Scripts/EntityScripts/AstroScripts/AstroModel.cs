using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AstroModel : EntityBase
{  
    private CharacterController controller;
    public GameObject player;

    public float Myspeed = 600.0f;
    public float turnSpeed = 400.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical") * Myspeed;
        }

        float turn = Input.GetAxis("Horizontal"); //Horizontal or Mouse X
       
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
      
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
    }
}