using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void ActivateButton(Button button, Action method)
    {
        button.onClick.AddListener(delegate
        {
            method();
        });
    }
    public void NewGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void Options()
    {
        //Debug.Log("OptionsPressed");
    }
    public void QuitToMainMenu()
    {
        //Debug.Log("PressingMainMenu");
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitToWindows()
    {
        Application.Quit();
    }

}
