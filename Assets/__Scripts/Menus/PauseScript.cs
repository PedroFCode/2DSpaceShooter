using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Button;
    public GameObject ResumeButton;
    private bool isPaused = false;


    void Start()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        Button.SetActive(false);
        ResumeButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
            Button.SetActive(true);
            ResumeButton.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);
            Button.SetActive(false);
            ResumeButton.SetActive(false);
        }
    }
}
