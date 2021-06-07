using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int breakableBlocks;

    private SceneLoader sceneLoader;

    private void Update()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextLevel();
        }
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
    }
}