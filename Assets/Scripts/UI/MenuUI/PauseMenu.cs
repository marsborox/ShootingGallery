using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : Menu
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button quitToMainMenuButton;
    [SerializeField] Button quitToWindowsButton;

    [SerializeField] PlayerController playerController;
    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    void Start()
    {
        ActivateButton(resumeButton, Resume);
        ActivateButton(restartButton, NewGame);
        ActivateButton(optionsButton, Options);
        ActivateButton(quitToMainMenuButton, QuitToMainMenu);
        ActivateButton(quitToWindowsButton, QuitToWindows);
    }
    public void Resume()
    {
        playerController.PauseMenuOff();
    }
}
