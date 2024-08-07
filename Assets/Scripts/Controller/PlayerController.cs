using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

public class PlayerController : MonoBehaviour
{
    [SerializeField] OnScreenStick onScreenStick = null;

    //Cached Components
    private Vector2 speedVector = Vector2.zero;
    private Vector2 lastSpeedVector = Vector2.zero;
    private bool isMoving = false;
    public Action MoveInput = null;
    public Action FireInput = null;

    private void Start()
    {
        
    }

    public void OnMove(InputValue value)
    {
        MoveInput?.Invoke();
        Vector2 moveDirection = value.Get<Vector2>();
        Debug.Log("" + moveDirection);
 
        if(Mathf.Abs(moveDirection.x) < .1f) moveDirection.x = 0;
        if(Mathf.Abs(moveDirection.y) < .1f) moveDirection.y = 0;
        isMoving = Convert.ToBoolean(moveDirection.magnitude);

        
        speedVector = moveDirection;

    }

    public void OnFire(InputValue value)
    {
        FireInput?.Invoke();
    }

    

    public Vector2 GetInputDirection()
    {
        return speedVector;
    }
}
