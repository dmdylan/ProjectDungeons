using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cinemachine;

public class CreateLocalPlayer : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //if (!isLocalPlayer) { return; }

        if (isLocalPlayer.Equals(true))
        {
           Camera.main.enabled = true;
        }
        else
            Camera.main.enabled = false;
 
        //cinemachineCamera = GetComponent<CinemachineFreeLook>();
    }
}
