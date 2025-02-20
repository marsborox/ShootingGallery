using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : Menu
{
    [SerializeField] Button optionsButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button quitToMainMenuButton;
    [SerializeField] Button quitToWindowsButton;
    void Start()
    {
        ActivateButton(restartButton, NewGame);
        ActivateButton(optionsButton, Options);
        ActivateButton(quitToWindowsButton, QuitToMainMenu);
        ActivateButton(quitToWindowsButton, QuitToWindows);
    }
}
