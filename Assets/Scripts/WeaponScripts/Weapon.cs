using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Weapon : ScriptableObject
{
    public float cooldown;
    public bool shootReady=true;

    public abstract void Shoot();
}
