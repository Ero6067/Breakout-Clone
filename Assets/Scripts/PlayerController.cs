using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;

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
        if (mouseIsActive)
        {
        float mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(mousePos, transform.position.y);
        transform.position = paddlePos;

        }
        if (controllerIsActive)
        {
            rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
            
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
        Debug.Log("Controller");
    }
}
