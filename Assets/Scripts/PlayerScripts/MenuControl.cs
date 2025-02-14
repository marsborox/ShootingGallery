using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MenuControl : MonoBehaviour
{
    Shooting shooting;
    PlayerControls playerControls;
    bool escapeMenuOn=false;

    private void Awake()
    {
        playerControls=new PlayerControls();
    }
    private void Start()
    {
        EnablePlayerInput();
    }
    private void OnEnable()
    {
        
    }
    void EnablePlayerInput()
    {
        playerControls.Menu.EscapeMenu.started += _ => EscapeMenu();
    }
    void EscapeMenu()
    {
        Debug.Log("Esc / o pressed");
        Debug.Log("esc pressed menu is"+ (escapeMenuOn ? "On" : "Off"));

    }
    void DisablePlayerInput()
    {
        //playerControls.Menu.EscapeMenu.canceled += _ => EscapeMenu();
    }
}
