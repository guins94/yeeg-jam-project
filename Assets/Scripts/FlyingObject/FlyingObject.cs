using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class FlyingObject : NetworkBehaviour
{
    [Header("Flyin Objects Configs")]
    [SerializeField] bool shouldHover = true;
    public float speed;
    [SerializeField] float hoverMaxDistance = 5f;
    [SerializeField] Vector2 hoverDirection = Vector2.zero;
    [SerializeField] bool hoverGoing = true;

    // Cached Components
    protected Vector2 currentPos => this.transform.position;
    private Vector2 initialPos = Vector2.zero;

    private void Start()
    {
        initialPos = this.transform.position;
    }

    public void Hover()
    {
        if (hoverMaxDistance <= Vector2.Distance(initialPos, currentPos))
        {
            hoverGoing = !hoverGoing;
        } 

        if (hoverGoing)
        {
            Vector2 targetPosition = currentPos + hoverDirection.normalized;
            Move(targetPosition);
        }
        else
        {
            Vector2 targetPosition = currentPos - hoverDirection.normalized;
            Move(targetPosition);
        }
    }

    public void Move(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void Update() => Hover();
}
