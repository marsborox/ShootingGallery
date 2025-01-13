using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class Shooting : MonoBehaviour
{
    PlayerControls playerControls;
    [SerializeField] Projectile projectilePrefab;
    Action shoot;
    Action reload;
    private IObjectPool<Projectile> projectilePool;

    public Weapon currentWeapon;
    [SerializeField] Weapon pistol;
    [SerializeField] Weapon shotgun;
    [SerializeField] Weapon machineGun;
    [SerializeField] UIWeapons uiWeapons;

    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int defaultCapacity = 10;
    [SerializeField] private int maxSize = 30;
    // Start is called before the first frame update
    private void Awake()
    {
        projectilePool = new ObjectPool<Projectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);
        playerControls=new PlayerControls();
        
    }

    void Start()
    {
        PlayerInput();
        SetPistol();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerInput();
    }
    void PlayerInput()
    {
        //shoot = playerControls.Shooting.Shoot();
        playerControls.Shooting.Shoot.started+= Shoot;
        playerControls.Shooting.Reload.started+= _ =>Reload();
        playerControls.WeaponSwitch.SetPistol.started += _ => SetPistol();
        playerControls.WeaponSwitch.SetShotgun.started += _ => SetShotgun();
        playerControls.WeaponSwitch.SetMachineGun.started += _ => SetMachineGun();
    }
    void Shoot(InputAction.CallbackContext context)
    {
        /*
        Debug.Log("Shooting. pew pew");
        projectilePool.Get();
        */

        if (currentWeapon.shootReady)
        { 
            currentWeapon.shootReady = false;
            currentWeapon.Shoot();
            StartCoroutine(ShootingRoutine());
        }
    }
    IEnumerator ShootingRoutine()
    {
        yield return new WaitForSeconds(currentWeapon.cooldown);
        currentWeapon.shootReady = true;
    }

    #region ProjectilePooling
    private Projectile CreateProjectile()
    { 
        Projectile projectileInstance = Instantiate(projectilePrefab);
        projectileInstance.projectilePoolPublic = projectilePool;
        return projectileInstance;
    }
    private void OnGetFromPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
    }
    private void OnReleaseToPool(Projectile projectile)
    { 
        projectile.gameObject.SetActive(false);
    }
    private void OnDestroyPooledObject(Projectile projectile)
    {
        Destroy(projectile.gameObject);
    }
    #endregion
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
    public void SetPistol()
    { 
        Debug.Log("shooting.pistol set");
        currentWeapon=pistol;
        uiWeapons.DisableImages();
        uiWeapons.PistolSetActiveUI();
    }
    public void SetShotgun()
    { 
        Debug.Log("shooting.shotgun set");
        currentWeapon=shotgun;
        uiWeapons.DisableImages();
        uiWeapons.ShotgunSetActiveUI();
    }
    public void SetMachineGun()
    {
        Debug.Log("shooting.machinegun set");
        currentWeapon=machineGun;
        uiWeapons.DisableImages();
        uiWeapons.MachineGunSetActiveUI();
    }
}
