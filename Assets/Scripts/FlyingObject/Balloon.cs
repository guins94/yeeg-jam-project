using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : Character
{
    [SerializeField] Rigidbody2D playerRigidbody = null;
    [SerializeField] PlayerController playerController = null;
    [SerializeField] float playerMaxSpeed = 4f;
    [SerializeField] float speedMultiplier = 2f;

    [SerializeField] float actionCooldownTimer = 2;
    [SerializeField] float dashMultiplier = 2f;

    //Cached Components
    private Vector2 playerCurrentSpeed = Vector2.zero;
    private bool actionCooldown = false;

    private void Start()
    {
        if (playerController != null)
        {
            playerController.MoveInput += MoveInput;
            playerController.FireInput += FireInput;
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

    /// <summary>
    /// If inside the editor, the action Fire was activated and the player makes the desired move
    /// If using a cellphone, use the button on screen
    /// </summary>
    void FireInput()
    {
        if (actionCooldown == true) return;
        playerCurrentSpeed = playerController.GetInputDirection();
        playerRigidbody.AddForce(playerCurrentSpeed * dashMultiplier);

        StartCoroutine(ActionCooldown());
    }

    private IEnumerator ActionCooldown()
    {
        actionCooldown = true;
        yield return new WaitForSeconds(actionCooldownTimer);
        actionCooldown = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //if(!IsOwner) return;

        playerRigidbody.AddForce(playerCurrentSpeed * speedMultiplier);
        playerRigidbody.velocity = new Vector3(Mathf.Clamp(playerRigidbody.velocity.x, -playerMaxSpeed, playerMaxSpeed), Mathf.Clamp(playerRigidbody.velocity.y, -playerMaxSpeed, playerMaxSpeed));

        base.Update();
    }
}
