using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : Parallax
{
    private float height = 0;
    public float startPos = 0;


    void Start()
    {
        startPos = transform.position.y;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    public override void ParallaxMove()
    {
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
