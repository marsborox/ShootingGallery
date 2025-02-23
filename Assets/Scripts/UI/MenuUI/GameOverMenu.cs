using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameOverMenu : Menu
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] Button restartButton;
    [SerializeField] Button quitToMainMenuButton;
    void Start()
    {
        score.text = FindObjectOfType<Score>().playerScore.ToString();
        ActivateButton(restartButton, NewGame);
        
        ActivateButton(quitToMainMenuButton, QuitToMainMenu);
    }
}
