using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    PlayerControls playerControls;
    [SerializeField] GameObject projectile;
    Action shoot;
    Action reload;

    // Start is called before the first frame update
    private void Awake()
    {
        //playerControls=GetComponent<PlayerControls>();
        //playerControls.onActionTriggered += Shoot;
        playerControls=new PlayerControls();
    }
    void Start()
    {
        PlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerInput();
    }
    void PlayerInput()
    {
        //shoot = playerControls.Shooting.Shoot();
        playerControls.Shooting.Shoot.started+= _ =>Shoot();
        playerControls.Shooting.Reload.started+= _ =>Reload();
    }
    void Shoot()
    {
        Debug.Log("Shooting. pew pew");
        Instantiate(projectile);
        
    }
    private void Reload()
    {
        Debug.Log("Shooting.Reloading");
    }
    void OnEnable()
    {
        playerControls.Enable();
    }
    void OnDisable()
    {
        playerControls.Disable();
    }
}
