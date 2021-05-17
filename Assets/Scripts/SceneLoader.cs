using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMenuScreen(string menuOption)
    {
        SceneManager.LoadScene(menuOption);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
