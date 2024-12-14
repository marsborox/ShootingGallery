using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Target>())
        {
            //other.gameObject.GetComponent<Target>().Die();

            other.gameObject.GetComponent<Target>().Deactivate();
            //Do Damage
            Debug.Log("Doing Le Damage");
        }
    }
    private void DoDamage()
    { 
        
    }
}
