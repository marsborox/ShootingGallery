using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunProjectile : Projectile
{
    float dispersion = 20;
    public void SetPosition()
    {
        Debug.Log("projectile. mouse posiiton");

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        //gameObject.transform.position = pz;
        gameObject.transform.position = Disperze(pz);
    }
}
