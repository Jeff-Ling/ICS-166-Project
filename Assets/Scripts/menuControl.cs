 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuControl : MonoBehaviour
{
    public static bool isPaused = false; 

    public GameObject pauseMenuUI;
    public GameObject inventoryPage;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                resumeButton();
            }
            else
            {
                pause();
            }
        }
    }

    void pause()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void resumeButton()
    {
        pauseMenuUI.SetActive(false);
        inventoryPage.SetActive(false); 
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void exitGameButton()
    {
        Application.Quit();
    }
}
