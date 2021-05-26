using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    private LevelManager level;

    private void Start()
    {
        level = FindObjectOfType<LevelManager>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.RemoveBlock();
        Destroy(gameObject);
    }
}