using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void Start()
    {

        //Debug.Log("projectile.Projectile spawned, starting routine");
        SetPosition();
        StartCoroutine(SpawnRoutine());
    }
    //int damage = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Target>())
        {
            //other.gameObject.GetComponent<Target>().Die();

            other.gameObject.GetComponent<Target>().Deactivate();
            //Do Damage
            //Debug.Log("projectile.Doing Le Damage");
        }
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        //Debug.Log("projectile.Projectile despawning");
        Destroy(gameObject);
    }
    void SetPosition() 
    {
        Debug.Log("projectile. mouse posiiton");
        
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;
  
    }
}
