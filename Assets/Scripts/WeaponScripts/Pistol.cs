using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Pistol", menuName = "Weapon/Pistol")]
public class Pistol : Weapon
{
    private void Awake()
    {
        cooldown = 0.7f;
    }
    public override void Shoot()
    {

            { Debug.Log("Pistol Shot"); }
            //throw new System.NotImplementedException();
       
    }

}
