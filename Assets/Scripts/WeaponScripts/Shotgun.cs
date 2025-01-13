using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun",menuName = "Weapon/Shotgun")]
public class Shotgun : Weapon
{
    private void Awake()
    {
        cooldown = 0.7f;
    }

    public override void Shoot()
    {
        { Debug.Log("Shotgun Shot"); }
        //throw new System.NotImplementedException();
    }
}
