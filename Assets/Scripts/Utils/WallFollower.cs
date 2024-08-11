using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WallFollower : MonoBehaviour
{
    [SerializeField] BoxCollider2D wallCollider = null;
    [SerializeField] Directions wallPosition = Directions.Top; 
    [SerializeField] float wallThickness = 1;

    [SerializeField] CinemachineVirtualCamera camera = null;

    private void Start()
    {
        switch (wallPosition)
            {
                case Directions.Left:
                    wallCollider.size = new Vector2(wallThickness, Camera.main.OrthographicBounds().max.y*2);
                    break;
                case Directions.Right:
                    wallCollider.size = new Vector2(wallThickness, Camera.main.OrthographicBounds().max.y*2);
                    break;
                case Directions.Top:
                    wallCollider.size = new Vector2(Camera.main.OrthographicBounds().max.x*2, wallThickness);
                    break;
                case Directions.Bottom:
                    wallCollider.size = new Vector2(Camera.main.OrthographicBounds().max.x*2, wallThickness);
                    break;
                default:
                    break;
            }
    }

    // Update is called once per frame
    void Update()
    {
        if (wallCollider != null && gameObject != null && camera != null)
        {
            switch (wallPosition)
            {
                case Directions.Left:
                    this.transform.position = new Vector3(-Camera.main.OrthographicBounds().max.x - wallThickness/2, camera.transform.position.y, camera.transform.position.z);
                    break;
                case Directions.Right:
                    this.transform.position = new Vector3(Camera.main.OrthographicBounds().max.x + wallThickness/2, camera.transform.position.y, camera.transform.position.z);
                    break;
                case Directions.Top:
                    this.transform.position = new Vector3(camera.transform.position.x, -Camera.main.OrthographicBounds().max.y - wallThickness/2, camera.transform.position.z);
                    break;
                case Directions.Bottom:
                    this.transform.position = new Vector3(camera.transform.position.x, Camera.main.OrthographicBounds().max.y + wallThickness/2, camera.transform.position.z);
                    break;
                default:
                    break;
            }
            
        }
    }

    // Trigger automatically shakes the screen in a minor way
    void OnCollisionEnter(Collision other)
    {   
        Debug.LogError("" + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            GlobalActions.MinorShake?.Invoke();
        }
    }

    // Trigger automatically shakes the screen in a minor way
    void OnCollisionEnter(Collider other)
    {
        Debug.LogError("" + other.name);
        if (other.CompareTag("Player"))
        {
            GlobalActions.MinorShake?.Invoke();
        }
    }
}
