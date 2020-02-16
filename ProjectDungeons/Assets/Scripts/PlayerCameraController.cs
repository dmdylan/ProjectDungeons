using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform player;
    public Camera playerCamera;

    public float RotationSpeed = 1;
    public float mouseX;
    public float mouseY;

    private void Awake()
    {
        playerCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
