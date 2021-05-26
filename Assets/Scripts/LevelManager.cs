using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int breakableBlocks;

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void RemoveBlock()
    {
        breakableBlocks--;
    }

    private void Update()
    {
        if (breakableBlocks == 0)
        {
            Debug.Log("Zero");
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}