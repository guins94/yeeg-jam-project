using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Header("Background References")]
    [SerializeField] GameObject camera = null;
    [SerializeField] float parallaxSpeed = 0;

    private float startPos = 0;
    private float height = 0;


    void Start()
    {
        startPos = transform.position.y;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void FixedUpdate()
    {
        float distance = camera.transform.position.y * parallaxSpeed;
        float movement = camera.transform.position.y * (1 - parallaxSpeed);

        transform.position = new Vector3(transform.position.x, startPos + distance, transform.position.z);

        if (movement > startPos + height)
        {
            startPos += height;
        }
        else if (movement < startPos - height)
        {
            startPos -= height;
        }
    }
}
