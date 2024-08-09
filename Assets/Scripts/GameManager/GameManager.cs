using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager GameManagerInstance { get; protected set; } = null;
    public static CinemachineVirtualCamera VirtualCameraInstance { get; protected set; } = null;
    private CameraShake cameraShake = null;

    // Start is called before the first frame update
    void Start()
    {
        GameManagerInstance = this;
        VirtualCameraInstance = FindObjectOfType<CinemachineVirtualCamera>();
        if (VirtualCameraInstance != null) cameraShake = VirtualCameraInstance.GetComponent<CameraShake>();
    }
}
