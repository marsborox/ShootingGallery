using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Weapon : MonoBehaviour
{
    public float cooldown;
    public float cooldownToReduce;
    public bool shootReady=true;

    [SerializeField] public bool weaponActive = false;
    [SerializeField] 
    public abstract void WeaponShoots();

    private void Update()
    {
        CooldownChecker();


    }

    void CooldownChecker()
    {
        if (!shootReady)
        {
            //UpdateCoolDownProgres(weapon)
            if (cooldownToReduce > 0)
            {
                cooldownToReduce = cooldownToReduce - cooldown * Time.deltaTime;
            }
            else
            {
                shootReady = true;
            }
            //here update interface
        }
    }
    public void WeaponPostShoot()
    {
        cooldownToReduce = cooldown;
        shootReady = false;
    }
}
