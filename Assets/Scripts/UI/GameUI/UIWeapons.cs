using UnityEngine;
public class UIWeapons : MonoBehaviour
{

    [SerializeField] GameObject uiRifleActive;
    [SerializeField] GameObject uiShotgunActive;
    [SerializeField] GameObject uiMachineGunActive;

    [SerializeField] UIWeapon uiRifle;
    [SerializeField] UIWeapon uiShotgun;
    [SerializeField] UIWeapon uimachineGun;

    [SerializeField] Rifle rifle;
    [SerializeField] Shotgun shotgun;
    [SerializeField] MachineGun machineGun;
    // Start is called before the first frame update
    Color32 normalColor = Color.white;
    Color32 reloadColor = Color.red;
    

    private void Awake()
    {
        
        
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        /*
        RifleCooldownFraction();
        ShotgunCooldownFraction();
        MachineGunCooldownFraction();
        */
        AllWeaponsFillDisplayAll();
    }
    #region active weapon selector must fix
    //only one square with changingp position
    public void DisableActiveUIs()
    {
        uiRifleActive.SetActive(false);
        uiShotgunActive.SetActive(false);
        uiMachineGunActive.SetActive(false);

        //uiPistol.GetComponent<UIWeapon>().activeBackground.SetActive(false);
    }
    public void RifleSetActiveUI()
    {
        uiRifleActive.SetActive(true);
    }
    public void ShotgunSetActiveUI()
    {
        uiShotgunActive.SetActive(true);
    }
    public void MachineGunSetActiveUI()
    {
        uiMachineGunActive.SetActive(true);
    }
    #endregion

    //needs to be reworked - if weapon is reloading or on cd perform this

    void FillAllFractions()
    {
        FillFractions(rifle,uiRifle);
        FillFractions(shotgun,uiShotgun);
        FillFractions(machineGun, uimachineGun);
    }
    void AllWeaponsFillDisplayAll()
    {
        UiWeaponDisplayFull(rifle, uiRifle);
        UiWeaponDisplayFull(shotgun, uiShotgun);
        UiWeaponDisplayFull(machineGun, uimachineGun);
    }
    void ColorChanger()
    { 
        
    }
    void UiWeaponDisplayFull(Weapon weapon, UIWeapon uiWeapon)
    {
        FillFractions(weapon, uiWeapon);
        DisplayAmmo(weapon, uiWeapon);
    }

    void FillFractions(Weapon weapon, UIWeapon uiWeapon)
    {
        if (weapon.reloading||(weapon.onCooldown))
        {
            if (weapon.reloading)
            {
                uiWeapon.WeaponSetColor(reloadColor);
                uiWeapon.CooldownFill(weapon.reloadTimeToReduce / weapon.reloadTime);
            }
            else 
            {
                uiWeapon.WeaponSetColor(normalColor);
                uiWeapon.CooldownFill(weapon.cooldownTimeToReduce / weapon.cooldownTime); 
            }
        }
        else uiWeapon.WeaponSetColor(normalColor);
    }

    void DisplayAmmo(Weapon weapon, UIWeapon uiWeapon)
    {
        uiWeapon.DisplayAmmo(weapon.ammo.ToString());
    }

    float Fill(float toReduce,float full )
    {
        return toReduce/ full;
    }

    void WhatToDo()
    {
        
    }
    
    void DoCooldown() { }
    void DoReload() { }


    public void RifleCooldownFraction()
    {
        uiRifle.CooldownFill(rifle.cooldownTimeToReduce/rifle.cooldownTime);
    }
    public void ShotgunCooldownFraction()
    {
        uiShotgun.CooldownFill(shotgun.cooldownTimeToReduce/shotgun.cooldownTime);
    }
    public void MachineGunCooldownFraction()
    {
        uimachineGun.CooldownFill(machineGun.cooldownTimeToReduce/machineGun.cooldownTime);
    }

    public void RifleReloadFraction()
    {

    }
    public void ShotgunReloadFraction() 
    { 
    
    }
    public void MachineGunReloadFraction() 
    { 
    
    }
}
