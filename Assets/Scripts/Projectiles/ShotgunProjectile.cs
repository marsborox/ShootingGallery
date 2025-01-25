using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectile : Projectile
{
    
    public override void SetPosition()
    {
        Debug.Log("Shotgun.projectile. mouse posiiton");

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;



        //gameObject.transform.position = pz;
        gameObject.transform.position = base.Disperze(pz);
    }
    
}
