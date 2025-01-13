using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeapons : MonoBehaviour
{

    [SerializeField] GameObject uiPistolActive;
    [SerializeField] GameObject uiShotgunActive;
    [SerializeField] GameObject machineGunActive;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisableImages()
    {
        uiPistolActive.SetActive(false);
        uiShotgunActive.SetActive(false);
        machineGunActive.SetActive(false);
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
        machineGunActive.SetActive(true);
    }
}
