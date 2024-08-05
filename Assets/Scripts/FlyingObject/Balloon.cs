using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : Character
{
    [SerializeField] Rigidbody2D playerRigidbody = null;
    [SerializeField] PlayerController playerController = null;
    [SerializeField] float playerMaxSpeed = 4f;
    [SerializeField] float speedMultiplier = 2f;
    private Vector2 playerCurrentSpeed = Vector2.zero;
    

    private void Start()
    {
        if (playerController != null)
        {
            playerController.MoveInput += MoveInput;
        }
    }

    /// <summary>
    /// If inside the editor, use the arrow keys to move left or right.
    /// If using a cellphone, use its tilt.
    /// </summary>
    void MoveInput()
    {
        playerCurrentSpeed = playerController.GetInputDirection();
    }

    // Update is called once per frame
    private void Update()
    {
        //if(!IsOwner) return;

        playerRigidbody.AddForce(playerCurrentSpeed * speedMultiplier);
        playerRigidbody.velocity = new Vector3(Mathf.Clamp(playerRigidbody.velocity.x, -playerMaxSpeed, playerMaxSpeed), Mathf.Clamp(playerRigidbody.velocity.y, -playerMaxSpeed, playerMaxSpeed));

        base.Update();
    }
}
