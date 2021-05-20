using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] PlayerController paddle1;

    // state
    Vector2 paddleToBallVec;
    Vector2 startPos;
    [SerializeField] float ballOffset = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y + ballOffset);
        transform.position = startPos;
        Debug.Log(startPos);
        paddleToBallVec = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVec;
    }
}
