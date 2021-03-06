﻿using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class MovementController : NetworkBehaviour
{
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private float speedSmoothTime = 0.1f;
    [SerializeField] private float gravity = 1f;
    [SerializeField] private float jumpForce = 20f;

    private CharacterController controller = null;
    private Animator animator = null;
    [SerializeField]private Transform mainCameraTransform = null;

    private float speedSmoothVelocity = 0f;
    private float currentSpeed = 0f;

    private static readonly int hashSpeedPercentage = Animator.StringToHash("SpeedPercentage");

    public override void OnStartLocalPlayer()
    {
        if (!isLocalPlayer)
            return;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (!hasAuthority) { return; }
        Move();
    }

    private void Move()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        Vector3 forward = mainCameraTransform.forward;
        Vector3 right = mainCameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = (forward * movementInput.y + right * movementInput.x).normalized;

        bool running = Input.GetKey(KeyCode.LeftShift);
        if (controller.isGrounded)
        {
            if (desiredMoveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), 0.1f);
            }

            //Speed variables
            float targetSpeed = ((running) ? runSpeed : movementSpeed) * movementInput.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

            if (Input.GetButtonDown("Jump"))
            {
                desiredMoveDirection.y = jumpForce;
            }
        }

        desiredMoveDirection.y -= gravity * Time.deltaTime;
        controller.Move(desiredMoveDirection * currentSpeed * Time.deltaTime);
     
        animator.SetFloat(hashSpeedPercentage, ((running) ? 1.0f : 0.5f) * movementInput.magnitude, speedSmoothTime, Time.deltaTime);
    }

}
