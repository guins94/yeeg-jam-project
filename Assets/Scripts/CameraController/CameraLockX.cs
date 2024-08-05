using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraLockX : CinemachineExtension
{
    [SerializeField] CinemachineVirtualCamera cameraLockX = null;
    private float startPos = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (cameraLockX == null)
        {
            cameraLockX = GetComponent<CinemachineVirtualCamera>();
        }
        startPos = cameraLockX.transform.position.x;
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (enabled && stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.x = startPos;
            state.RawPosition = pos;
        }
    }

}
