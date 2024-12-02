using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine; //Adding "Untiy" to this took too long to figure out...
                         //It's only needed in Unity 6...

public class CameraController : Singleton<CameraController>
{
    private CinemachineCamera cinemachineCamera;

    public void SetPlayerCameraFollow() {
        cinemachineCamera = FindObjectOfType<CinemachineCamera>();
        cinemachineCamera.Follow = PlayerController.Instance.transform;
    }
}
