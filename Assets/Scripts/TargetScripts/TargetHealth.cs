using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
//using UnityEngine.UIElements;
using UnityEngine.UI;
public class TargetHealth : MonoBehaviour
{
    public int healthMax=20;
    public int healthCurrent;
    Target target;

    [SerializeField]Image healthBar;
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
        
        healthCurrent = healthMax;
        healthBar.fillAmount = 1;
    }
    private void OnDisable()
    {
    }
    public void TakeDamage(int damage)
    {
        healthCurrent -= damage;
        float fillAmount = (float) healthCurrent / (float)healthMax;
        healthBar.fillAmount = fillAmount;
        if (healthCurrent <= 0)
        { 
            target.Die();
        }
    }

}
