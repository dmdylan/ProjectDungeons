using UnityEngine.InputSystem;
using UnityEngine;
using UnityEditor.Experimental;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private InputAction movement;
    [Space] [SerializeField] private InputActionAsset playerControls;
    private void Awake()
    {
        var gameplayActionMap = playerControls.FindActionMap("Gameplay");

        movement = gameplayActionMap.FindAction("Movement");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMovementChanged(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();

        //Direction = new Vector3(direction.x, 0, direction.y);
    }

    private void OnEnable()
    {
        movement.Enable();
    }
}
