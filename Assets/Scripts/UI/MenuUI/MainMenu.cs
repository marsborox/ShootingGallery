using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : Menu
{
    [SerializeField] Button newGameButton;
    [SerializeField] Button quitToWindowsButton;
    [SerializeField] Button optionsButton;
    
    
    void Start()
    {
        ActivateButton(newGameButton,NewGame);
        //ActivateButton(optionsButton,Options);
        ActivateButton(quitToWindowsButton,QuitToWindows);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
