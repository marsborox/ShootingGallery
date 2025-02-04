using UnityEngine;
public class UIWeapons : MonoBehaviour
{

    [SerializeField] GameObject uiRifleActive;
    [SerializeField] GameObject uiShotgunActive;
    [SerializeField] GameObject uiMachineGunActive;

    [SerializeField] UIWeapon uiRifle;
    [SerializeField] UIWeapon uiShotgun;
    [SerializeField] UIWeapon uimachineGun;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableActiveUIs()
    {
        uiRifleActive.SetActive(false);
        uiShotgunActive.SetActive(false);
        uiMachineGunActive.SetActive(false);

        //uiPistol.GetComponent<UIWeapon>().activeBackground.SetActive(false);
    }
    public void PistolSetActiveUI()
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
}
