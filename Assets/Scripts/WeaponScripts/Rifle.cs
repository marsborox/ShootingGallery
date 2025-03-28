
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class Rifle : Weapon
{
    private IObjectPool <Projectile> rifleShotPool;

    private void Awake()
    {
        base.Awake();
        rifleShotPool =new ObjectPool<Projectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);//
    }
    private void Start()
    {
        
    }

    public override void WeaponShoots()
    {
        //Debug.Log("Rifle Shot");
        //throw new System.NotImplementedException();
        rifleShotPool.Get();
        audioPlayer.PlayClip(shootAudioClip);
        //base.WeaponShoots();
        //Debug.Log("Rifle PostShot");
        //projectileInstance.transform.position= 
    }
    
    Projectile CreateProjectile()
    {
        Projectile projectileInstance = Instantiate(projectilePrefab);
        projectileInstance.projectilePoolPublic = rifleShotPool;
        return projectileInstance;
    }
    /*
    private void OnGetFromPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
    }
    private void OnReleaseToPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }
    private void OnDestroyPooledObject(Projectile projectile)
    {
        Destroy(projectile.gameObject);
    }*/

}
