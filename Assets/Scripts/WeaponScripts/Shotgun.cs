using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun",menuName = "Weapon/Shotgun")]
public class Shotgun : Weapon
{
    

    public override void Shoot(GameObject gameObject)
    {
        { Debug.Log("Shotgun Shot"); }
        throw new System.NotImplementedException();
    }
}
