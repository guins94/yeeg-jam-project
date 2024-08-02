using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material material;
    float distanceWidth = 0;
    float distanceHeight = 0;

    [Range(0f,0.5f)]
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;    
    }

    // Update is called once per frame
    void Update()
    {
        distanceWidth += Time.deltaTime*speed;
        material.SetTextureOffset("_MainTex", Vector2.right * distanceWidth);

        distanceHeight += Time.deltaTime*speed;
        material.SetTextureOffset("_MainTex", Vector2.up * distanceHeight);
    }
}
