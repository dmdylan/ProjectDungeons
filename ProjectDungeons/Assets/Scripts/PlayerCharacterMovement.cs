using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    private Animator playerAnimator;
    public Transform target;
    private Camera playerCamera;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float horizontalMovementInput;
    private float forwardMovementInput;
    private float verticalMovement;

    private float mouseX;
    private float mouseY;
    [SerializeField] private float rotationSpeed = 5;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float gravity = 1f;

    private void Awake()
    {
        playerCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMovementInput = Input.GetAxisRaw("Horizontal");
        forwardMovementInput = Input.GetAxisRaw("Vertical");
        MoveThePlayer();
    }

    private void LateUpdate()
    {
        RotateThePlayer();
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
        Cursor.lockState = CursorLockMode.Locked;
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -60, 60);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.rotation = Quaternion.Euler(0, mouseX, 0);
    }

    private void MoveThePlayer()
    {
        verticalMovement = -.001f; 
        if (characterController.isGrounded)
        {
            moveDirection = transform.TransformDirection(new Vector3(horizontalMovementInput, verticalMovement, forwardMovementInput)).normalized;
            moveDirection *= moveSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
