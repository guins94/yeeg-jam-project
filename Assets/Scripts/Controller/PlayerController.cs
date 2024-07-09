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

    private void Start()
    {
        //onScreenStick.m_PointerDownAction.canceled += onScreenStick.OnPointerUp;
    }

    private void OnMove(InputValue value)
    {
        Vector2 moveDirection = value.Get<Vector2>();
 
        if(Mathf.Abs(moveDirection.x) < .1f) moveDirection.x = 0;
        if(Mathf.Abs(moveDirection.y) < .1f) moveDirection.y = 0;
        isMoving = Convert.ToBoolean(moveDirection.magnitude);

        if(isMoving)
        {
            speedVector = moveDirection;
        } 
    }

    public Vector2 GetInputDirection()
    {
        return speedVector;
    }
}
