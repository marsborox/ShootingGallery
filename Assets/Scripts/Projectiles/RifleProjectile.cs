using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleProjectile : Projectile
{
    public override void SetPosition()
    {
        //Debug.Log("Rifle.projectile. mouse posiiton");
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;
    }
}
