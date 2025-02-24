using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerControls playerControls;
    Shooting shooting;
    [SerializeField] GameObject uiPauseMenu;

    public bool pauseMenuOn = false;
    void Awake()
    {
        playerControls = new PlayerControls();
        shooting=GetComponent<Shooting>();
    }
    void Start()
    {
        EnablePlayerInput();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnEnable()
    {
        playerControls.Enable();
        uiPauseMenu=FindObjectOfType<PauseMenu>().gameObject;
    }
    void OnDisable()
    {
        playerControls.Disable();
    }
    public void EnablePlayerInput()
    {
        //shoot = playerControls.Shooting.Shoot();
        playerControls.Shooting.Shoot.started += shooting.Shoot;
        playerControls.Shooting.Shoot.canceled += shooting.StopShoot;
        playerControls.Shooting.Reload.started +=  shooting.Reload;
        playerControls.WeaponSwitch.SetPistol.started +=  shooting.SetRifle;
        playerControls.WeaponSwitch.SetShotgun.started +=  shooting.SetShotgun;
        playerControls.WeaponSwitch.SetMachineGun.started +=  shooting.SetMachineGun;
        playerControls.MenuControl.EscapeMenu.started +=  PauseMenu;

    }
    public void DisablePlayerInput()
    {
        //shoot = playerControls.Shooting.Shoot();

        playerControls.Shooting.Shoot.started -= shooting.Shoot;
        playerControls.Shooting.Shoot.canceled -= shooting.StopShoot;
        playerControls.Shooting.Reload.started -=  shooting.Reload;
        playerControls.WeaponSwitch.SetPistol.started -=  shooting.SetRifle;
        playerControls.WeaponSwitch.SetShotgun.started -=  shooting.SetShotgun;
        playerControls.WeaponSwitch.SetMachineGun.started -=  shooting.SetMachineGun;
        playerControls.MenuControl.EscapeMenu.started -=  PauseMenu;
    }

    void DisableWeaponActionsControls()
    {
        playerControls.Shooting.Shoot.started -= shooting.Shoot;
        playerControls.Shooting.Shoot.canceled -= shooting.StopShoot;
        playerControls.Shooting.Reload.started -=  shooting.Reload;
        playerControls.WeaponSwitch.SetPistol.started -=  shooting.SetRifle;
        playerControls.WeaponSwitch.SetShotgun.started -=  shooting.SetShotgun;
        playerControls.WeaponSwitch.SetMachineGun.started -=  shooting.SetMachineGun;
    }
    void EnableWeaponActionsControls()
    {
        playerControls.Shooting.Shoot.started += shooting.Shoot;
        playerControls.Shooting.Shoot.canceled += shooting.StopShoot;
        playerControls.Shooting.Reload.started +=  shooting.Reload;
        playerControls.WeaponSwitch.SetPistol.started +=  shooting.SetRifle;
        playerControls.WeaponSwitch.SetShotgun.started +=  shooting.SetShotgun;
        playerControls.WeaponSwitch.SetMachineGun.started +=  shooting.SetMachineGun;
    }





    void PauseMenu(InputAction.CallbackContext context)
    {
        if (pauseMenuOn)
        {
            PauseMenuOff();
        }
        else
        {
            PauseMenuOn();
        }
        Debug.Log("Esc / o pressed");
        Debug.Log("esc pressed menu is" + (pauseMenuOn ? "On" : "Off"));
    }
    void PauseMenuOn()
    { 
        pauseMenuOn = true;
        Time.timeScale = 0f;
        DisableWeaponActionsControls();
        uiPauseMenu.SetActive(true);
    }
    void PauseMenuOff()
    { 
        pauseMenuOn = false;
        Time.timeScale = 1f;
        EnableWeaponActionsControls();
        uiPauseMenu.SetActive(false);
    }


}
