using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    // Reference to the Cinemachine Virtual Camera
    private CinemachineVirtualCamera virtualCamera;

    // Reference to the Cinemachine Perlin component
    private CinemachineBasicMultiChannelPerlin perlin;

    // Variables to control shake intensity and duration
    private float shakeDuration = 0f;
    private float shakeTimer = 0f;
    private float initialAmplitude;

    void Start()
    {
        // Get the Virtual Camera component
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        // Get the Perlin noise component
        perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        // Store the initial amplitude
        initialAmplitude = perlin.m_AmplitudeGain;
    }

    void Update()
    {
        // If the shake is active, update the timer
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            // If the timer runs out, stop the shake
            if (shakeTimer <= 0)
            {
                perlin.m_AmplitudeGain = initialAmplitude; // Reset to initial amplitude
            }
        }
    }

    // Method to trigger the camera shake
    public void ShakeCamera(float intensity, float duration)
    {
        perlin.m_AmplitudeGain = intensity; // Set shake intensity
        shakeDuration = duration; // Set shake duration
        shakeTimer = shakeDuration; // Reset the timer
    }
}