using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunProjectile : Projectile
{
    
    public override void SetPosition()
    {
        Debug.Log("MachineGun.projectile. mouse posiiton");

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        //gameObject.transform.position = pz;
        Vector2 position = Disperze(pz);
        gameObject.transform.position = position;
    }
}
