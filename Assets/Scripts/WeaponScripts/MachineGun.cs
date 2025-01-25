using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class MachineGun : Weapon
{
    private IObjectPool<Projectile> machineGunShotPool;

    private void Awake()
    {

        machineGunShotPool = new ObjectPool<Projectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);//
    }
    private void Start()
    {

    }
    public override void WeaponShoots()
    {
        Debug.Log("Rifle Shot");
        //throw new System.NotImplementedException();
        machineGunShotPool.Get();
        Debug.Log("Rifle PostShot");
        //projectileInstance.transform.position= 
        base.WeaponPostShoot();
    }

    Projectile CreateProjectile()
    {
        Projectile projectileInstance = Instantiate(projectilePrefab);
        projectileInstance.projectilePoolPublic = machineGunShotPool;
        return projectileInstance;
    }
}
