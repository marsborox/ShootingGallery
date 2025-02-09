
using System;

using UnityEngine;
using UnityEngine.Pool;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] public float cooldown;
    [SerializeField] public float cooldownToReduce;
    public bool shootReady=true;

    [SerializeField] public Projectile projectilePrefab;
    [SerializeField] public bool weaponActive = false;
    

    [SerializeField] public bool collectionCheck = true;
    [SerializeField] public int defaultCapacity = 10;
    [SerializeField] public int maxSize = 30;

    [SerializeField] public int ammoMax=10;
    [SerializeField] public int ammo = 10;
    [SerializeField] public float reloadTime;
    [SerializeField] public float reloadTimeToReduce;
    public bool reloading = false;

    public abstract void WeaponShoots();

    public void Update()
    {
        CooldownChecker();
        ReloadingChecker();

    }

    void CooldownChecker()
    {
        if (!shootReady)
        {
            //UpdateCoolDownProgres(weapon)
            if (cooldownToReduce > 0)
            {
                cooldownToReduce = cooldownToReduce - /*cooldown * */ Time.deltaTime;
            }
            else
            {
                shootReady = true;
            }
            //here update interface
        }
 
    }
    void ReloadingChecker()
    {
        if (reloading)
        {
            if (reloadTimeToReduce > 0)
            {
                reloadTimeToReduce = reloadTimeToReduce - Time.deltaTime;
            }
            else 
            {
                ammo = ammoMax;
                reloading = false;
            }
        }
    }
    public void Shoot(Action action) 
    {
        if (ammo <= 0)
        {
            shootReady = false;
            return;
        }

        if (shootReady && !reloading)
        {
            action();
            cooldownToReduce = cooldown;
            shootReady = false;
            ammo--;
        }
    }
    void Shoot()
    { 
        
    }
    void DoShot()
    { 
    
    }
    public void WeaponPreShoot()
    { 
        if (ammo <= 0)
        {
            shootReady = false;
        }
    }

    public void WeaponReload()
    {
        Debug.Log("weapon.performingReload");
        //will trigger reloading process actual reload is in Checker
        if (!reloading)
        {
            reloading = true;
            reloadTimeToReduce = reloadTime;
        }
    }

    public Projectile CreateProjectile(ObjectPool<Projectile> pool)
    {
        Projectile projectileInstance = Instantiate(projectilePrefab);
        projectileInstance.projectilePoolPublic = pool;
        return projectileInstance;
    }
    public void OnGetFromPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
    }
    public void OnReleaseToPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }
    public void OnDestroyPooledObject(Projectile projectile)
    {
        Destroy(projectile.gameObject);
    }

}
