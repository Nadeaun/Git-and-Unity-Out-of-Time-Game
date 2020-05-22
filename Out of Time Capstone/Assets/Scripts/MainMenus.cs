using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenus : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Main_Cabin");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
