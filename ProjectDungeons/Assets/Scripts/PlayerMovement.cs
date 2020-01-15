using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //PlayerController playerControls;
    Vector2 i_movement;
    private void Awake()
    {
        //playerControls = new PlayerController();
    }

    private void OnEnable()
    {
       // playerControls.Combat.Enable();
    }

    private void OnDisable()
    {
       // playerControls.Combat.Disable();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(i_movement.x, 0, i_movement.y) * 5 * Time.deltaTime;
        transform.Translate(movement);
        Debug.Log(i_movement);
    }

    private void OnMove(InputValue value)
    {
        i_movement = value.Get<Vector2>();
        
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        //var movementInput = playerControls.Combat.Movement.ReadValue<Vector2>();
        //Debug.Log(movementInput);
        //var movement = new Vector3
        //{
        //    x = movementInput.x,
        //    z = movementInput.y
        //};
        //
        //transform.Translate(movement * 2 * Time.deltaTime);
    }   
}
