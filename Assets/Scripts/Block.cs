using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameStatus gameStatus;
    private LevelManager level;
    [SerializeField] private int pointValue = 5;

    private void Start()
    {
        level = FindObjectOfType<LevelManager>();
        level.CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroyed();
        gameStatus.ScorePoints(pointValue);
        Destroy(gameObject);
    }
}