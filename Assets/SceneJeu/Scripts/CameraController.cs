using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera thirdPartyCamera;
    public Camera topDownCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c")) 
        {
            thirdPartyCamera.enabled = !thirdPartyCamera.enabled;
            topDownCamera.enabled = !topDownCamera.enabled;
        }
    }
}
