using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
   Transform gameCamera = null;
   Vector3 cameraStartPos = Vector3.zero;
   float distance = 0;

   GameObject[] backgrounds = null;
   Material[] materials= null;
   float[] backgroundSpeed = null;

   [Range(0.01f, 0.05f)]
   public float parallaxSpeed = 0;

   float farthestBack = 0;

   void Start()
   {
        gameCamera = Camera.main.transform;
        cameraStartPos = gameCamera.transform.position;

        int backCount = transform.childCount;
        materials = new Material[backCount];
        backgroundSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            materials[i] = backgrounds[i].GetComponent<Renderer>().material;
        }

        BackSpeedCalculate(backCount);
   }

   void BackSpeedCalculate(int backCount)
   {
        for (int i = 0; i < backCount; i++)
        {
            if ((backgrounds[i].transform.position.z - gameCamera.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - gameCamera.position.z;
            }
        }

        for (int i = 0; i < backCount; i++)
        {
            backgroundSpeed[i] = 1 - (backgrounds[i].transform.position.z - gameCamera.position.z) / farthestBack;
        }
   }

   private void LateUpdate()
   {
        distance = gameCamera.position.x - cameraStartPos.x;

        for (int i = 0; i < backgrounds.Length ;i++)
        {
            float speed = backgroundSpeed[i] * parallaxSpeed;
            materials[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
   }

   private void FixedUpdate()
   {
        transform.position = new Vector3(gameCamera.position.x,  gameCamera.position.y, 0);
   }
}
