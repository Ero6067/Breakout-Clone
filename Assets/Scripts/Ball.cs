using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] private PlayerController paddle1;

    [SerializeField] private float xSpeed = 2f;
    [SerializeField] private float ySpeed = 15f;
    [SerializeField] private float ballOffset = 0.5f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] ballSounds;

    private bool hasStarted = false;
    private Vector2 startPos;

    private void Awake()
    {
        PlaceBallOnStartingArea();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, transform.position.y);
        if (!hasStarted)
        {
            paddlePos.x = Mathf.Clamp(paddlePos.x, 1.5f, 14.5f);
        }

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
            GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, ySpeed);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            PlayBounceSounds(collision);
        }
    }

    private void PlayBounceSounds(Collision2D collision)
    {
        if (collision.gameObject.tag != "Breakable")
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}