using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

//using Unity.VisualScripting;
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
    Weapon rifle;
    Weapon shotgun;
    Weapon machineGun;
    [SerializeField] UIWeapons uiWeapons;

    

    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int defaultCapacity = 10;
    [SerializeField] private int maxSize = 30;
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
        SetPistol();
        CreateWeaponArray();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerInput();
        WeaponCooldownChecker();
    }
    void EnablePlayerInput()
    {
        //shoot = playerControls.Shooting.Shoot();
        playerControls.Shooting.Shoot.started+= Shoot;
        playerControls.Shooting.Reload.started+= _ =>Reload();
        playerControls.WeaponSwitch.SetPistol.started += _ => SetPistol();
        playerControls.WeaponSwitch.SetShotgun.started += _ => SetShotgun();
        playerControls.WeaponSwitch.SetMachineGun.started += _ => SetMachineGun();
    }
    void DisablePlayerInput()
    {
        //shoot = playerControls.Shooting.Shoot();
        playerControls.Shooting.Shoot.started -= Shoot;
        playerControls.Shooting.Reload.started -= _ => Reload();
        playerControls.WeaponSwitch.SetPistol.started -= _ => SetPistol();
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
        if (currentWeapon.shootReady && !(currentWeapon is MachineGun))
        {
            currentWeapon.WeaponShoots();
            currentWeapon.cooldownToReduce = currentWeapon.cooldown;
            currentWeapon.shootReady = false;
            /*currentWeapon.shootReady = false;
            currentWeapon.Shoot();
            StartCoroutine(ShootingRoutine());*/
        }
        else if (currentWeapon.shootReady && (currentWeapon is MachineGun))
        { 
            
        }
    }
    IEnumerator ShootingRoutine()
    {
        Weapon usedWeapon=currentWeapon;
        Debug.Log("shooting.ShootingRoutine"+usedWeapon.cooldown.ToString());
        yield return new WaitForSeconds(usedWeapon.cooldown);
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
        Debug.Log("shooting.rifle set");

        currentWeapon=rifle;
        uiWeapons.DisableActiveUIs();
        uiWeapons.PistolSetActiveUI();
    }
    public void SetShotgun()
    { 
        Debug.Log("shooting.shotgun set");

        currentWeapon=shotgun;
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
    void UpdateCoolDownProgres(Weapon weapon)
    {
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
