﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private AudioClip partialBreakSound;
    [SerializeField] private GameObject blockParticlesVfx;
    [SerializeField] private GameSession gameStatus;
    [SerializeField] private int pointValue = 5;
    [SerializeField] private int maxHits;

    [SerializeField] private Sprite[] hitSprites;

    private LevelManager level;

    [SerializeField] private int timesHit; //exposed for debugging only

    private void Awake()
    {
        gameStatus = FindObjectOfType<GameSession>();
    }

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<LevelManager>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
            AudioSource.PlayClipAtPoint(partialBreakSound, Camera.main.transform.position);
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
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