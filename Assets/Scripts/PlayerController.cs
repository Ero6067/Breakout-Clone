﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float xMin = 1, xMax = 15;

    [SerializeField] bool mouseIsActive = false;
    [SerializeField] bool controllerIsActive = true;

    [SerializeField] Vector2 moveVal;
    [SerializeField] float moveSpeed = 5f;
    private float inputX;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (mouseIsActive)
        {
            float mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            Vector2 paddlePos = new Vector2(mousePos, transform.position.y);
            paddlePos.x = Mathf.Clamp(mousePos, xMin, xMax);

            transform.position = paddlePos;

        }
        else if (controllerIsActive)
        {
            rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
            Vector2 clampedPos = transform.position;
            clampedPos.x = Mathf.Clamp(clampedPos.x, xMin, xMax);
            transform.position = clampedPos;

        }
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }
}
