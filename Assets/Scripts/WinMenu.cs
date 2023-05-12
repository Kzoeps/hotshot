using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void playAgain() {
        SceneManager.LoadScene("test-scene");

    }

    public void mainMenu()
    {
        SceneManager.LoadScene("menuScene");
    }


}
