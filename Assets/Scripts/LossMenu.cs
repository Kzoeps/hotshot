using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossMenu : MonoBehaviour
{
    public void retryAgain() {
        SceneManager.LoadScene("test-scene");

    }

    public void mainMenu()
    {
        SceneManager.LoadScene("menuScene");

    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

}
