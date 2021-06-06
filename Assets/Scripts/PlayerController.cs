using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float xMin = 1, xMax = 15;

    [SerializeField] public bool mouseIsActive = false;

    [SerializeField] private Vector2 moveVal;
    [SerializeField] private float moveSpeed = 5f;
    private float inputX;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
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
        else
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

    public void OnToggleControlType(InputAction.CallbackContext context)
    {
        mouseIsActive = !mouseIsActive;
        Debug.Log(mouseIsActive);
    }
}