using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Parallax : MonoBehaviour
{
    [Header("Background References")]
    [SerializeField] GameObject camera = null;
    [SerializeField] float parallaxSpeed = 0;

    // Public Reference
    public GameObject cameraRefence => camera;
    public float parallaxSpeedReference => parallaxSpeed;

    // Important 
    public float distance => cameraRefence.transform.position.y * parallaxSpeedReference;
    public float movement => cameraRefence.transform.position.y * (1 - parallaxSpeedReference);
        

    void FixedUpdate() => ParallaxMove(); 

    public abstract void ParallaxMove();
}
