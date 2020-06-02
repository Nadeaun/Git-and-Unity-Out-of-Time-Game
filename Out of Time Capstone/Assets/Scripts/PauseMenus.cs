using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenus : MonoBehaviour
{

    public bool GameIsPaused = false;
    public GameObject pauseMenusUI;

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

    void Resume()
    {
        pauseMenusUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("/First Person Player/Main Camera").GetComponent<MouseLook>().mouseLookOn = true;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenusUI.SetActive(true);
        //Time.timeScale = 0f;
        GameIsPaused = true;
        GameObject.Find("/First Person Player/Main Camera").GetComponent<MouseLook>().mouseLookOn = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
