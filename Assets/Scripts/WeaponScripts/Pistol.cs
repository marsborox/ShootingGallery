using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pistol", menuName = "Weapon/Pistol")]
public class Pistol : Weapon
{
    public override void Shoot()
    {
        { Debug.Log("Pistol Shot"); }
        //throw new System.NotImplementedException();
    }
}
