using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MachineGun", menuName = "Weapon/MachineGun")]
public class MachineGun : Weapon
{
    public override void Shoot(GameObject gameObject)
    {
        { Debug.Log("MachineGun"); }
        throw new System.NotImplementedException();
    }
}
