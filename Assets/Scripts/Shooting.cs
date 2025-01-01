using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class Shooting : MonoBehaviour
{
    PlayerControls playerControls;
    [SerializeField] Projectile projectilePrefab;
    Action shoot;
    Action reload;

    private IObjectPool<Projectile> projectilePool;

    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int defaultCapacity = 10;
    [SerializeField] private int maxSize = 30;
    // Start is called before the first frame update
    private void Awake()
    {
        projectilePool = new ObjectPool<Projectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);
        playerControls=new PlayerControls();
    }
    void Start()
    {
        PlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerInput();
    }
    void PlayerInput()
    {
        //shoot = playerControls.Shooting.Shoot();
        playerControls.Shooting.Shoot.started+= _ =>Shoot();
        playerControls.Shooting.Reload.started+= _ =>Reload();
    }
    void Shoot()
    {
        Debug.Log("Shooting. pew pew");
        projectilePool.Get();
        
    }

    #region ProjectilePooling
    private Projectile CreateProjectile()
    { 
        Projectile projectileInstance = Instantiate(projectilePrefab);
        projectileInstance.projectilePoolPublic = projectilePool;

        return projectileInstance;
    }
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
    }

    #endregion


    private void Reload()
    {
        Debug.Log("Shooting.Reloading");
    }
    void OnEnable()
    {
        playerControls.Enable();
    }
    void OnDisable()
    {
        playerControls.Disable();
    }
}
