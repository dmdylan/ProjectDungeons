using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerControls = null;

    private void Awake() => playerControls = new PlayerController();
    private void OnEnable() => playerControls.Combat.Enable();
    private void OnDisable() => playerControls.Combat.Disable();
    private void Update() => MovePlayer();

    private void MovePlayer()
    {
        var movementInput = playerControls.Combat.Movement.ReadValue<Vector2>();
        Debug.Log(movementInput);
        var movement = new Vector3
        {
            x = movementInput.x,
            z = movementInput.y
        };

        Debug.Log(movement);
        transform.Translate(movement * 2 * Time.deltaTime);
    }
    
}
