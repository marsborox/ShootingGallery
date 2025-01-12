using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MachineGun", menuName = "Weapon/MachineGun")]
public class MachineGun : Weapon
{
    public override void Shoot()
    {
        { Debug.Log("MachineGun"); }
        //throw new System.NotImplementedException();
    }
}
