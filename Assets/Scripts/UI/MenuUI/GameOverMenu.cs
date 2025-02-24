using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : Menu
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] Button restartButton;
    [SerializeField] Button quitToMainMenuButton;
    Score scoreObject;
    void Start()
    {
        //SetScoreText();
        //score.text = FindObjectOfType<Score>().playerScore.ToString();
        ActivateButton(restartButton, NewGame);
        ActivateButton(quitToMainMenuButton, QuitToMainMenu);
    }
    private void OnEnable()
    {
        SetScoreText();
    }
    private void OnDisable()
    {
        
    }
    public void SetScoreText()
    {
        score.text = FindObjectOfType<Score>().playerScore.ToString();
    }
}
