using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cinemachine;

public class CreateLocalPlayer : NetworkBehaviour
{
    [SerializeField] private CinemachineFreeLook freeLookCam = null;
    [SerializeField] private Camera playerCamera = null;
    [SerializeField] private Transform player = null;
    [SerializeField] private Transform target = null;
    
    public override void OnStartLocalPlayer()
    {
        freeLookCam.gameObject.SetActive(false);

        if (!isLocalPlayer)
        {
            return;
        }
        else
        {
            playerCamera.gameObject.SetActive(true);
            freeLookCam.gameObject.SetActive(true);
            freeLookCam.Follow = player;
            freeLookCam.LookAt = target;
        }
    }
}
