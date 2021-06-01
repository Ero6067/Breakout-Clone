using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //Range turns the var into a slider in the inspector
    [Range(0.1f, 5f)] [SerializeField] private float gameSpeed = 1f;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI HiScoreText;
    [SerializeField] private int currentScore = 0;

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    private void Update()
    {
    }

    public void ScorePoints(int val)
    {
        currentScore += val;
        scoreText.text = currentScore.ToString();
    }
}