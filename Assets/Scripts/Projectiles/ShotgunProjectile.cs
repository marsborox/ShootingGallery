using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectile : Projectile
{
    float dispersion = 5;
    public void SetPosition()
    {
        Debug.Log("projectile. mouse posiiton");

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        //gameObject.transform.position = pz;
        gameObject.transform.position = base.Disperze(pz);
    }
    
}
