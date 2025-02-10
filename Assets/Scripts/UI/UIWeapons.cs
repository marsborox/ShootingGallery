using UnityEditor.ShaderKeywordFilter;

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

    private void Awake()
    {
        
        
    }
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        RifleCooldownFraction();
        ShotgunCooldownFraction();
        MachineGunCooldownFraction();


    }

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


    //needs to be reworked - if weapon is reloading or on cd perform this

    public void RifleCooldownFraction()
    {
        uiRifle.CooldownFill(rifle.cooldownToReduce/rifle.cooldown);
    }
    public void ShotgunCooldownFraction()
    {
        uiShotgun.CooldownFill(shotgun.cooldownToReduce/shotgun.cooldown);
    }
    public void MachineGunCooldownFraction()
    {
        uimachineGun.CooldownFill(machineGun.cooldownToReduce/machineGun.cooldown);
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
