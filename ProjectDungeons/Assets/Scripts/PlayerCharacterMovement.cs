using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    private Animator playerAnimator;
    private Camera playerCamera;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float horizontalMovementInput;
    private float forwardMovementInput;
    private float verticalMovement;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float gravity = 1f;

    private void Awake()
    {
        playerCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
    }

    //private void Update()
    //{
    //    //Debug.Log(moveDirection);
    //    horizontalMovementInput = Input.GetAxisRaw("Horizontal");
    //    forwardMovementInput = Input.GetAxisRaw("Vertical");
    //}

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(playerCamera.transform.position, transform.forward * 20, Color.blue);
        horizontalMovementInput = Input.GetAxisRaw("Horizontal");
        forwardMovementInput = Input.GetAxisRaw("Vertical");
        MoveThePlayer();
        RotateWithCamera();
        Debug.Log("Hori" + horizontalMovementInput);
        Debug.Log("Vert" + forwardMovementInput);
    }

    private void RotateWithCamera()
    {
        if (Input.GetMouseButton(1))
        {
            float yRotation = playerCamera.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

    private void RotateThePlayer()
    {
        //float angle = Mathf.Atan2(horizontalMovementInput, forwardMovementInput) * Mathf.Rad2Deg;  
        if (Input.GetMouseButton(1))
            return;       

        //The chacter faces the direciton of the input
        //But the movement then applies based on the character rotation
        //So the chacter turns rotates left when A is held down, but then moves towards the left of the new rotation direction
        transform.rotation = Quaternion.LookRotation(new Vector3(horizontalMovementInput,0,forwardMovementInput));
    }

    private void MoveThePlayer()
    {
        verticalMovement = -.001f; 
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(horizontalMovementInput, verticalMovement, forwardMovementInput).normalized;


            moveDirection *= moveSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        RotateThePlayer();
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
        
    }
}
