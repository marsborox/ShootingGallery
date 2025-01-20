using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class Shotgun : Weapon
{
    private IObjectPool<Projectile> shotgunShellPool;
    private void Start()
    {
        cooldown = 0.7f;
    }

    public override void WeaponShoots()
    {
        { Debug.Log("Shotgun Shot"); }
        //throw new System.NotImplementedException();
        base.WeaponPostShoot();
    }
}
