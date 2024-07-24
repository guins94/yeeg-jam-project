using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Header("Background References")]
    [SerializeField] GameObject BrotherBackground = null;
    [SerializeField] BoxCollider2D backgroundCollider;
    [SerializeField] Rigidbody2D backgroundRigidbody2D = null;
    [SerializeField] bool shouldGoUp = true;

    private float width;

    private float height;

    private float speed = 0;

    void Start()
    {
        backgroundRigidbody2D.velocity = new Vector2(speed, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (shouldGoUp)
                gameObject.transform.position = new Vector2(BrotherBackground.transform.position.x, BrotherBackground.transform.position.y + height);
            else
                gameObject.transform.position = new Vector2(BrotherBackground.transform.position.x + width, BrotherBackground.transform.position.y);
        }
    }
}
