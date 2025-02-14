using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

using UnityEngine;
using UnityEngine.Pool;


public class Shotgun : Weapon
{
    private IObjectPool<Projectile> shotGunShotPool;
    [SerializeField] int numberOfShots = 5; 
    
    private void Awake()
    {

        shotGunShotPool = new ObjectPool<Projectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);//
    }
    private void Start()
    {

    }


    public override void WeaponShoots()
    {
        Debug.Log("Shotgun Shot");
        //throw new System.NotImplementedException();
        for (int i = 0; i < numberOfShots; i++)
        {
            shotGunShotPool.Get();
        }
    }

    Projectile CreateProjectile()
    {
        Projectile projectileInstance = Instantiate(projectilePrefab);
        projectileInstance.projectilePoolPublic = shotGunShotPool;
        return projectileInstance;
    }
}
