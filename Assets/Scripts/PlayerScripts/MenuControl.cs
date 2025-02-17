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

}
