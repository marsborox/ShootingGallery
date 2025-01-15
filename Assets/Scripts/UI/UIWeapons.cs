using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeapons : MonoBehaviour
{

    [SerializeField] GameObject uiPistolActive;
    [SerializeField] GameObject uiShotgunActive;
    [SerializeField] GameObject uiMachineGunActive;

    [SerializeField] GameObject uiPistol;
    [SerializeField] GameObject uiShotgun;
    [SerializeField] GameObject uimachineGun;



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
        uiPistolActive.SetActive(false);
        uiShotgunActive.SetActive(false);
        uiMachineGunActive.SetActive(false);

        //uiPistol.GetComponent<UIWeapon>().activeBackground.SetActive(false);
    }
    public void PistolSetActiveUI()
    {
        uiPistolActive.SetActive(true);
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
