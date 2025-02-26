using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class MachineGun : Weapon
{
    private IObjectPool<Projectile> machineGunShotPool;
    Shooting shooting;
    private void Awake()
    {
        base.Awake();
        machineGunShotPool = new ObjectPool<Projectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);
        shooting = GetComponent<Shooting>();
    }
    private void Start()
    {

    }
    private void Update()
    {
            base.Update();
        //here insert continuous shooting for machinegun
        if (shooting.autoShooting)
        {
            base.Shoot(ContinuousShooting);
        }
    }
    public override void WeaponShoots()
    {
            
            //projectileInstance.transform.position= 
    }

    void ContinuousShooting()
    {
        Debug.Log("MachineGun Shot");
        //throw new System.NotImplementedException();
        machineGunShotPool.Get();
        audioPlayer.PlayClip(shootAudioClip);
        //base.WeaponShoots();
        Debug.Log("MachineGun PostShot");
    }

    Projectile CreateProjectile()
    {
        Projectile projectileInstance = Instantiate(projectilePrefab);
        projectileInstance.projectilePoolPublic = machineGunShotPool;
        return projectileInstance;
    }
}
