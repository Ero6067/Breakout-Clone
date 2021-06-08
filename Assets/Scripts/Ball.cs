using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] private PlayerController paddle1;

    [SerializeField] private float xSpeed = 2f;
    [SerializeField] private float ySpeed = 15f;
    [SerializeField] private float ballOffset = 0.5f;
    [SerializeField] private float randomFactor = 0.2f;
    [SerializeField] private AudioClip[] ballSounds;

    private AudioSource audioSource;
    private Rigidbody2D rb;

    private bool hasStarted = false;
    private Vector2 startPos;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

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
            hasStarted = true;
            rb.velocity = new Vector2(xSpeed, ySpeed);
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
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));
        float randomAngle = Random.Range(-randomFactor, randomFactor);

        if (collision.gameObject.CompareTag("Unbreakable"))
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
            //rb.velocity += velocityTweak;
            rb.velocity = Quaternion.Euler(0, 0, randomAngle) * rb.velocity;
        }
    }
}