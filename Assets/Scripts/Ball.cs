using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] private PlayerController paddle1;

    [SerializeField] private float xSpeed = 2f;
    [SerializeField] private float ySpeed = 15f;
    [SerializeField] private float ballOffset = 0.5f;
    [SerializeField] private AudioClip[] ballSounds;
    private bool hasStarted = false;
    private Vector2 startPos;
    private AudioSource myAudioSource;

    private void Awake()
    {
        PlaceBallOnStartingArea();
    }

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
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

        transform.position = paddlePos;
    }

    private void PlaceBallOnStartingArea()
    {
        startPos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y + ballOffset);
        transform.position = startPos;
        Vector2 paddleToBallVec = transform.position - paddle1.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasStarted)
        {
            //TODO make a better random system
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (!hasStarted)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, ySpeed);
            hasStarted = true;
        }
    }

    #region Arkanoid

    //https://noobtuts.com/unity/2d-arkanoid-game
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "racket")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            if (hasStarted)
                // Set Velocity with dir * speed
                GetComponent<Rigidbody2D>().velocity = dir * xSpeed;
        }
    }

    private float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    #endregion Arkanoid
}