using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CameraShake>().ShakeCamera(10, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
