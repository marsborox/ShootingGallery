using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.Pool;
using static UnityEngine.ParticleSystem;
public class TargetHealth : MonoBehaviour
{
    public int healthMax=20;
    public int healthCurrent;
    Target target;

    private BleedParticlePool particles;

    [SerializeField]Image healthBar;
    // Start is called before the first frame update
    [SerializeField] ParticleSystem hitEffect;
    private void Awake()
    {
        particles = FindObjectOfType<BleedParticlePool>();
        target = GetComponent<Target>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnEnable()
    {
        healthCurrent = healthMax;
        healthBar.fillAmount = 1;
    }
    private void OnDisable()
    {
    }
    public void TakeDamage(int damage)
    {
        healthCurrent -= damage;
        healthBar.fillAmount = (float) healthCurrent / (float)healthMax;
        PlayHitEffect();
        //healthBar.fillAmount = fillAmount;
        if (healthCurrent <= 0)
        { 
            target.Die();
        }
    }
    void PlayHitEffect()
    {
        particles.SpawnBleedParticle(target);

        //particles.bleedObjectPoolPublic.Get();

        /*
        ParticleSystem instance = Instantiate(hitEffect,transform.position, Quaternion.identity);
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        Destroy(this.gameObject);
        */
    }
}
