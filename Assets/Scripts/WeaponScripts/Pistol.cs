using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Pistol : Weapon
{

    
    private void Start()
    {
        cooldown = 0.7f;
    }
    public override void Shoot()
    {

            { Debug.Log("Pistol Shot"); }
            //throw new System.NotImplementedException();
       
    }

}
