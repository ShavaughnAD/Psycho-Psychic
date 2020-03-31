using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelSelect;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject quitPrompt;

    public void GotoLevel1()
    {
        //SceneManager.LoadScene("Test");
    }
    public void GotoLevel2()
    {
        //SceneManager.LoadScene("Popup Text Test");
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void OpenLevelSelect()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
        settings.SetActive(false);
        credits.SetActive(false);
        quitPrompt.SetActive(false);
    }
    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(false);
        settings.SetActive(true);
        credits.SetActive(false);
        quitPrompt.SetActive(false);
    }
    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(true);
        quitPrompt.SetActive(false);
    }
    public void OpenQuitPrompt()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(false);
        quitPrompt.SetActive(true);
    }
    public void ClosePrompts()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(false);
        quitPrompt.SetActive(false);
    }
}
