using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    //Range turns the var into a slider in the inspector
    [Range(0.1f, 5f)] [SerializeField] private float gameSpeed = 1f;

    [SerializeField] private int currentScore = 0;

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void ScorePoints(int val)
    {
        currentScore += val;
    }
}