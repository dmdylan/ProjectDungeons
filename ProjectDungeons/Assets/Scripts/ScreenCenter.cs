using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCenter : MonoBehaviour
{
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Screen.width * .5f, Screen.height * .5f);
    }
}
