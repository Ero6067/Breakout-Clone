using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneLoader : MonoBehaviour
{
    private PlayerController playerController;

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    playerController.mouseIsActive = true;
        //}
    }

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