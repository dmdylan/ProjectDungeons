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
    }

    private void RotateWithCamera()
    {
        if (Input.GetMouseButton(1))
        {
            float yRotation = playerCamera.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

    //Player rotation. Movement inputs are taken in at set at default 1 or -1 because of normal vectors, and then mutiplied by moveSpeed value. 
    //So they become 5 or -5

    private void RotateThePlayer()
    {
        float angle = Mathf.Atan2(horizontalMovementInput, forwardMovementInput) * Mathf.Rad2Deg;
        
        if (Input.GetMouseButton(1))
            return;

        if (angle == 90 || angle == -90 || angle == 180 || angle == 135 || angle == -135)
            return;

        //transform.Rotate(transform.up, angle, Space.Self);
        //transform.rotation = Quaternion.Euler(0, angle, 0);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, angle, 0), 0);
        //transform.eulerAngles = new Vector3 (0,angle,0);
        Debug.Log(angle);
    }

    private void MoveThePlayer()
    {
        verticalMovement = -.001f; 
        if (characterController.isGrounded)
        {
            moveDirection = transform.TransformDirection(horizontalMovementInput, verticalMovement, forwardMovementInput).normalized;
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
