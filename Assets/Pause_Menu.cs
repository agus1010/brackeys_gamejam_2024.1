using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    private bool PauseGame = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(PauseGame)
            {
                Resume();
            }
            else
            {
                Time.timeScale = 0f;
                PauseMenu.SetActive(true);
            }
        }
    }


    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Leave()
    {
        Application.Quit();
    }
}
