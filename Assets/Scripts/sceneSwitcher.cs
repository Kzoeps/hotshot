using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneSwitcher : MonoBehaviour
{
    public void nextScene() {
        SceneManager.LoadScene("test-scene");

    }

    public void prevScene()
    {
        SceneManager.LoadScene("menuScene");

    }

    public void goToTutorial() {
        SceneManager.LoadScene("tutorial");
    }
    public void toMenuFromTutorial()
    {
        SceneManager.LoadScene("menuScene");

    }


    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

}
