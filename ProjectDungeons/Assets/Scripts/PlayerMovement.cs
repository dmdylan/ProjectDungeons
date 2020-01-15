using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerController playerControls;

    private void Awake() => playerControls = new PlayerController();
    private void OnEnable() => playerControls.Combat.Enable();
    private void OnDisable() => playerControls.Combat.Disable();
    private void Update()
    {
      
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        var movementInput = playerControls.Combat.Movement.ReadValue<Vector2>();
        Debug.Log(movementInput);
        var movement = new Vector3
        {
            x = movementInput.x,
            z = movementInput.y
        };

        transform.Translate(movement * 2 * Time.deltaTime);
    }   
}
