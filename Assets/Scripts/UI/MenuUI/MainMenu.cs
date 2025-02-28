using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : Menu
{
    [SerializeField] Button newGameButton;
    [SerializeField] Button controlsButton;
    [SerializeField] Button quitToWindowsButton;

    [SerializeField] Button controlsExitButton;
    [SerializeField] GameObject controlsMenu;
    
    void Start()
    {
        ActivateButton(newGameButton,NewGame);
        //ActivateButton(optionsButton,Options);
        ActivateButton(quitToWindowsButton,QuitToWindows);
        ActivateButton(controlsButton, ControlsButtonMethod);
        ActivateButton(controlsExitButton,ControlsButtonMethod);
    }
    void ControlsButtonMethod()
    { 
        if (controlsMenu.activeSelf)
        {
            controlsMenu.SetActive(false);
        }
        else controlsMenu.SetActive(true);
    }
 }
