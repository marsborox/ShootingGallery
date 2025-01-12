using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun",menuName = "Weapon/Shotgun")]
public class Shotgun : Weapon
{
    void Awake()
    { 
    
    }

    public override void Shoot()
    {
        { Debug.Log("Shotgun Shot"); }
        //throw new System.NotImplementedException();
    }
}
