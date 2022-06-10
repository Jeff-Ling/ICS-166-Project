 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    public static bool isPaused = false; 

    public GameObject ExitPage;
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
        inventoryPage.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void newGameButton()
    {
        SceneManager.LoadScene(2);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void creditButton()
    {
        SceneManager.LoadScene(4);
    }

    public void backToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void resumeButton()
    {
        ExitPage.SetActive(false);
        inventoryPage.SetActive(false); 
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void exitGameButton()
    {
        Application.Quit();
        Debug.Log("Quit Success.");
    }
}
