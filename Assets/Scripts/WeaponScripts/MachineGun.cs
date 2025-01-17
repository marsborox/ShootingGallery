using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MachineGun : Weapon
{
    private void Start()
    {
        cooldown = 0.2f;
    }
    public override void WeaponShoots()
    {
        { Debug.Log("MachineGun"); }
        //throw new System.NotImplementedException();
        base.WeaponPostShoot();
    }
}
