using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class Shooting : MonoBehaviour
{
    PlayerControls playerControls;
    [SerializeField] Projectile projectilePrefab;

    private IObjectPool<Projectile> projectilePool;

    public Weapon currentWeapon;
    Weapon rifle;
    Weapon shotgun;
    Weapon machineGun;
    [SerializeField] UIWeapons uiWeapons;

    

    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int defaultCapacity = 10;
    [SerializeField] private int maxSize = 30;

    public bool autoShooting = false;
    // Start is called before the first frame update

    List <Weapon> weapons = new List<Weapon>();
    private void Awake()
    {
        projectilePool = new ObjectPool<Projectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);
        playerControls=new PlayerControls();
        rifle = GetComponent<Rifle>();
        shotgun = GetComponent<Shotgun>();
        machineGun = GetComponent<MachineGun>();
    }

    void Start()
    {
        EnablePlayerInput();
        SetRifle();
        CreateWeaponArray();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerInput();
        //WeaponCooldownChecker();
        if (currentWeapon is MachineGun&& currentWeapon.onCooldown&&autoShooting)
        {
            currentWeapon.WeaponShoots();
        }
    }
    void EnablePlayerInput()
    {
        //shoot = playerControls.Shooting.Shoot();
        playerControls.Shooting.Shoot.started+= Shoot;
        playerControls.Shooting.Shoot.canceled+= StopShoot;
        playerControls.Shooting.Reload.started+= _ =>Reload();
        playerControls.WeaponSwitch.SetPistol.started += _ => SetRifle();
        playerControls.WeaponSwitch.SetShotgun.started += _ => SetShotgun();
        playerControls.WeaponSwitch.SetMachineGun.started += _ => SetMachineGun();

    }
    void DisablePlayerInput()
    {
        //shoot = playerControls.Shooting.Shoot();
        playerControls.Shooting.Shoot.started -= Shoot;
        playerControls.Shooting.Shoot.canceled -= StopShoot;
        playerControls.Shooting.Reload.started -= _ => Reload();
        playerControls.WeaponSwitch.SetPistol.started -= _ => SetRifle();
        playerControls.WeaponSwitch.SetShotgun.started -= _ => SetShotgun();
        playerControls.WeaponSwitch.SetMachineGun.started -= _ => SetMachineGun();
    }
    void CreateWeaponArray()
    { 
        
        weapons.Add(rifle) ;
        weapons.Add(shotgun) ;
        weapons.Add(machineGun) ;

    }
    void Shoot(InputAction.CallbackContext context)
    {
        if (!(currentWeapon is MachineGun))
        {
            currentWeapon.Shoot(currentWeapon.WeaponShoots);

        }
        else if (currentWeapon is MachineGun)
        { 
            autoShooting = true;
        }
    }
    void StopShoot(InputAction.CallbackContext context)
    {
        autoShooting = false;
    }
    IEnumerator ShootingRoutine()
    {
        Weapon usedWeapon=currentWeapon;
        Debug.Log("shooting.ShootingRoutine"+usedWeapon.cooldownTime.ToString());
        yield return new WaitForSeconds(usedWeapon.cooldownTime);
        currentWeapon.onCooldown = true;
    }

    #region ProjectilePooling
    private Projectile CreateProjectile()
    { 
        Projectile projectileInstance = Instantiate(projectilePrefab);
        projectileInstance.projectilePoolPublic = projectilePool;
        //projectileInstance.shooting = this;
        return projectileInstance;
    }
    private void OnGetFromPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
       /* projectile.SetDamage(activeWeapon.damage);*/
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
        Debug.Log("Shooting.ReloadingChecker");
        currentWeapon.WeaponReload();
        autoShooting = false;
    }
    void OnEnable()
    {
        playerControls.Enable();
        
    }
    void OnDisable()
    {
        playerControls.Disable();
    }
    
    public void SetRifle()
    { 
        Debug.Log("shooting.rifle set");

        currentWeapon=rifle;
        autoShooting = false;
        uiWeapons.DisableActiveUIs();
        uiWeapons.RifleSetActiveUI();
    }
    public void SetShotgun()
    { 
        Debug.Log("shooting.shotgun set");

        currentWeapon=shotgun;
        autoShooting = false;
        uiWeapons.DisableActiveUIs();
        uiWeapons.ShotgunSetActiveUI();
    }
    public void SetMachineGun()
    {
        Debug.Log("shooting.machinegun set");

        currentWeapon=machineGun;
        uiWeapons.DisableActiveUIs();
        uiWeapons.MachineGunSetActiveUI();

    }
    
/*
    public void WeaponCooldownChecker()
    {
        foreach (Weapon weapon in weapons)
        {
            if (!weapon.shootReady)
            {
                //UpdateCoolDownProgres(weapon)
                if (weapon.cooldownToReduce > 0)
                {
                    weapon.cooldownToReduce = weapon.cooldownToReduce - weapon.cooldown * Time.deltaTime;
                }
                else
                {
                    weapon.shootReady = true;
                }
            }
        }
    }
*/
 
}
