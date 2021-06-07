using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockParticlesVfx;
    [SerializeField] private GameSession gameStatus;
    private LevelManager level;
    [SerializeField] private int pointValue = 5;

    private void Start()
    {
        level = FindObjectOfType<LevelManager>();
        level.CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerParticlesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        gameStatus.ScorePoints(pointValue);
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerParticlesVFX()
    {
        GameObject particles = Instantiate(blockParticlesVfx, transform.position, transform.rotation);
        Destroy(particles, 2f);
    }
}