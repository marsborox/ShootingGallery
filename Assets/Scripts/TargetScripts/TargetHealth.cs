using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class TargetHealth : MonoBehaviour
{
    public int healthMax=20;
    public int healthCurrent;
    Target target;


    // Start is called before the first frame update

    private void Awake()
    {
        target = GetComponent<Target>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        healthCurrent = healthMax;
    }
    public void TakeDamage(int damage)
    { 
        healthCurrent-=damage;
        if (healthCurrent <= 0)
        { 
            target.Die();
        }
    }

}
