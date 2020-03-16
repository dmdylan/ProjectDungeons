using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cinemachine;

public class CreateLocalPlayer : NetworkBehaviour
{
    private Camera playerCamera;
    public CinemachineFreeLook cinemachineCamera;
    GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        if (!hasAuthority) { return; }
        playerCamera = Camera.main;
        cinemachineCamera.Follow = this.transform;
        cinemachineCamera.LookAt = GetComponentInChildren<Transform>().Find("Target");
    }
}
