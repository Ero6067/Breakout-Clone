using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //Range turns the var into a slider in the inspector
    //[Range(0.1f, 5f)] [SerializeField] private float gameSpeed = 1f;

    private PlayerController playerController;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text HiScoreText;
    [SerializeField] private TMP_Text mouseToggle;
    [SerializeField] public int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        scoreText.text = currentScore.ToString();
        mouseToggle.text = playerController.mouseIsActive.ToString();
    }

    private void Update()
    {
    }

    public void ScorePoints(int val)
    {
        currentScore += val;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
        currentScore = 0;
    }
}