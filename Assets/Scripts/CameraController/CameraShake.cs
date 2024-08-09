using UnityEngine;
using Cinemachine;
using System.Collections.Generic;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    // Reference to the Cinemachine Virtual Camera
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    // Reference to the Cinemachine Perlin component
    [SerializeField] CinemachineBasicMultiChannelPerlin perlin;

    [Header("Shake Settings")]
    [SerializeField] ShakeSettings minorShake;

    // Cached Components
    private float initialAmplitude;
    private float initialFrequency;

    void Awake()
    {
        // Get the Virtual Camera component
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        // Get the Perlin noise component
        perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        // Store the initial amplitude
        initialAmplitude = perlin.m_AmplitudeGain;

        // Store the initial frequency
        initialAmplitude = perlin.m_FrequencyGain;

        //Starts to listen to Minor Camera Shake
        GlobalActions.MinorShake += MakeMinorShake;
    }

    public void ShakeCamera(float intensity, float duration, float frequency)
    {
        if (virtualCamera.IsValid) StartCoroutine(ShakeCameraCoroutine(intensity, duration, frequency));
    }

    private IEnumerator ShakeCameraCoroutine(float intensity, float duration, float frequency)
    {   
        perlin.m_AmplitudeGain = intensity; // Set amplitude
        perlin.m_FrequencyGain = frequency; // Set frequency
        yield return new WaitForSeconds(duration);
        perlin.m_AmplitudeGain = initialAmplitude; // Reset to initial amplitude
        perlin.m_FrequencyGain = frequency; // Reset to Initial frequency
    }

    private void MakeMinorShake()
    {
        if (virtualCamera.IsValid) StartCoroutine(ShakeCameraCoroutine(minorShake.intensity, minorShake.duration, minorShake.frequency));
    }
}