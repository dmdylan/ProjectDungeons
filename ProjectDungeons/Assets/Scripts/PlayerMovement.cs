using System;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(Collider))]
//[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnimator;
    private Camera playerCamera;
    private CharacterController characterController;

    Vector2 playerRotationInput;
    Vector2 wasdInput;
    Vector3 walkVelocity;
    Vector3 moveDirection;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 250f;

    private void Awake()
    {
        playerCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        RotateWithCamera();
    }

    #region Jump Logic

    private void OnJump(InputValue value)
    {
        if (value.isPressed && characterController.isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        moveDirection.y = jumpForce;
    }

    #endregion

    private void RotateWithCamera()
    {
        if (Input.GetMouseButton(1))
        {
            float yRotation = playerCamera.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation, transform.rotation.eulerAngles.z);
        }        
    }

    #region Movement Logic
    private void OnMovement(InputValue value)
    {
        wasdInput = value.Get<Vector2>();
        ProcessMovementInput();       
    }
    
    private void ProcessMovementInput()
    {
        //Reset movement velocity
        walkVelocity = Vector3.zero;

        //By default, the input is a float. Which makes the speed ramp up/down.
        //Setting the input values to either 1/-1 fixes this making the movement crisp by starting and stopping instantly.

        //Set vertical value
        float vval = 0f;
        if(wasdInput.y > 0f) { vval += 1f; }
        else if (wasdInput.y <0) { vval -= 1f; }

        //Set horizontal input value
        float hval = 0f;
        if(wasdInput.x > 0f) { hval += 1f; }
        else if (wasdInput.x < 0f) { hval -= 1f; }

        //Set vertical movement velocity
        if(vval != 0) { walkVelocity += Vector3.forward * vval; }

        //Set horizontal movement veloctiy
        if(hval != 0) { walkVelocity += Vector3.right * hval; } 

        if(hval == 0 && vval == 0)
        {
            playerAnimator.SetBool("isMoving", false);
        }
        else
        {
            playerAnimator.SetBool("isMoving", true);
        }     
    }

    private void Move()
    {
        if(wasdInput == Vector2.zero) { walkVelocity = Vector3.zero; }
        Vector3 moveDirection = new Vector3(walkVelocity.x, 0, walkVelocity.z).normalized * moveSpeed * Time.deltaTime;
        moveDirection.y -= 20f * Time.deltaTime;
        characterController.Move(moveDirection);
    }
    #endregion
}
