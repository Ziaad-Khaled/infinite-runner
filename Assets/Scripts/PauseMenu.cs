using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject androidButtonsUI;
    public AudioSource pauseSound;
    public AudioSource gamePlaySound;

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!gameIsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        gamePlaySound.Pause();
        
        pauseSound.Play();
        pauseMenuUI.SetActive(true);
        androidButtonsUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void MoveToScene(int sceneID)
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        // if(sceneID == 1)
        //     androidButtonsUI.SetActive(true);
        SceneManager.LoadScene(sceneID);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        androidButtonsUI.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseSound.Stop();
        gamePlaySound.UnPause();
            
            
    }

    
}
