﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [Tooltip("Speed the player will move at.")]
    public float speed = 7.5f;

    [Tooltip("Speed the player will move while jumping.")]
    private float jumpSpeed = 30.0f;

    [Tooltip("The pressure of gravity for the player.")]
    public float gravity = 20.0f;

    [Tooltip("Set to the Main Camera. Make Main Camera a child to this object.")]
    public Camera playerCamera;

    [Tooltip("The speed the camera will turn at.")]
    public float cameraSpeed = 2.0f;

    [Tooltip("The view range of the camera.")]
    public float cameraViewLimit = 60.0f;

    public CharacterController characterController;
    public Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    [HideInInspector]
    public bool canMove = true;

    public bool jump = false;

    public GameObject child;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;

    }

    void Update()
    {


        //Basic Movement Controlls
        if (characterController.isGrounded)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;
            Vector3 right = transform.TransformDirection(Vector3.right).normalized;

            float curSpeedX = speed * Input.GetAxis("Vertical");
            float curSpeedY = speed * Input.GetAxis("Horizontal");

            moveDirection = ((forward * curSpeedX) + (right * curSpeedY)).normalized;
            moveDirection *= speed;
            child.transform.rotation = Quaternion.LookRotation(moveDirection * -1);
            Jump();
            //jump = false;
        }

        //Gravity
        moveDirection.y -= gravity * Time.deltaTime;


        //Movement Speed
        characterController.Move(moveDirection * Time.deltaTime);

        //Camera rotation
        /*if (canMove)
        {
            rotation.x += -Input.GetAxis("Mouse Y") * cameraSpeed;
            rotation.y += Input.GetAxis("Mouse X") * cameraSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -cameraViewLimit, cameraViewLimit);

            playerCamera.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
        }*/

    }

    public void Jump()
    {
        if (jump)
        {
            moveDirection.y = jumpSpeed;
            jump = false;
        }
    }
}
