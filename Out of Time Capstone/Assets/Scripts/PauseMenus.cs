using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenus : MonoBehaviour
{

    public bool GameIsPaused = false;
    public GameObject pauseMenusUI;
    public GameObject PauseMenuPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Standard resume function undoing all that was done to "pause" the game in the first place
    public void Resume()
    {
        pauseMenusUI.SetActive(false);
        Time.timeScale = 1f; //Unnecessary
        Debug.Log("resume game");
        GameIsPaused = false;
        Debug.Log(GameIsPaused);
        Debug.Log("resume game after its false");
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("/First Person Player/Main Camera").GetComponent<MouseLook>().mouseLookOn = true;
        Cursor.visible = false;
    }

    // This is strictly for the resume button so that it can reference the proper game object in terms of disabling the GameIsPaused bool
    public void Resume2()
    {
        pauseMenusUI.SetActive(false);
        Time.timeScale = 1f; //Unnecessary
        Debug.Log("resume game"); //DEBUG
        PauseMenuPanel.GetComponent<PauseMenus>().GameIsPaused = false;
        Debug.Log(GameIsPaused); //DEBUG
        Debug.Log("resume game after its false"); //DEBUG
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("/First Person Player/Main Camera").GetComponent<MouseLook>().mouseLookOn = true;
        Cursor.visible = false;
    }

    // Pausing the game
    void Pause()
    {
        pauseMenusUI.SetActive(true);
        //Time.timeScale = 0f;
        GameIsPaused = true;
        GameObject.Find("/First Person Player/Main Camera").GetComponent<MouseLook>().mouseLookOn = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Take you back to the home screen/main menus
    public void QuitGame()
    {
        SceneManager.LoadScene("Main_Menus");
    }
}
