using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectScroller : Parallax
{
    public float startPos = 0;
    
    void Start()
    {
        startPos = transform.position.y;
    }

    public override void ParallaxMove()
    {
        transform.position = new Vector3(transform.position.x, startPos + distance, transform.position.z);
    }
}
