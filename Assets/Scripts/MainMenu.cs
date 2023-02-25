using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script that handles most of the things for the main menu
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject levelSelectPanel;


    public void OpenCreditsPanel()
    {
        creditsPanel.gameObject.SetActive(true);
    }
    
    public void CloseCreditsPanel()
    {
        creditsPanel.gameObject.SetActive(false);

    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void OpenLevelPanel()
    {
        levelSelectPanel.gameObject.SetActive(true);
    }
    
    public void CloseLevelPanel()
    {
        levelSelectPanel.gameObject.SetActive(false);

    }
   
}
