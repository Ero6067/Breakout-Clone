using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] private PlayerController paddle1;

    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;

    private bool hasStarted = false;
    private Vector2 startPos;
    [SerializeField] private float ballOffset = 0.5f;

    private void Awake()
    {
        PlaceBallOnStartingArea();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!hasStarted)
            LockBallToPaddle();
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, transform.position.y);

        transform.position = paddlePos;
    }

    private void PlaceBallOnStartingArea()
    {
        startPos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y + ballOffset);
        transform.position = startPos;
        Vector2 paddleToBallVec = transform.position - paddle1.transform.position;
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (!hasStarted)
        {
            Debug.Log("Shots Fired");
            //Unity zeroing the vec2 vars in the inspector??
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }
}