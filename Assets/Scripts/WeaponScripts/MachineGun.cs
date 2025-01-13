using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MachineGun", menuName = "Weapon/MachineGun")]
public class MachineGun : Weapon
{
    private void Awake()
    {
        cooldown = 0.2f;
    }
    public override void Shoot()
    {
        { Debug.Log("MachineGun"); }
        //throw new System.NotImplementedException();
    }
}
