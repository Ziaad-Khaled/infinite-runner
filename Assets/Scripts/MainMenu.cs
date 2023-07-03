using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject options;
    public GameObject howToPlay;
    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NavigateToOptions()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }

    public void NavigateToHowToPlay()
    {
        options.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void NavigateToCredits()
    {
        options.SetActive(false);
        credits.SetActive(true);
    }

    public void NavigateBackToOptions()
    {
        howToPlay.SetActive(false);
        credits.SetActive(false);
        options.SetActive(true);
    }

    public void NavigateBackToMainMenu()
    {
        options.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ToggleSound()
    {
        Sound.ToggleSound();
    }

    public void Quit()
    {
        Application.Quit();
    }

    
}
