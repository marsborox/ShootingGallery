using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    private IObjectPool<Projectile> projectilePoolPrivate;
    public IObjectPool<Projectile> projectilePoolPublic { set => projectilePoolPrivate = value; }
    private void Start()
    {

        //Debug.Log("projectile.Projectile spawned, starting routine");
        
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
    private void OnEnable()
    {
        SetPosition();
        StartCoroutine(SpawnRoutine());
    }

    public void Deactivate()
    {
        projectilePoolPrivate.Release(this);
    }
    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        //Debug.Log("projectile.Projectile despawning");
        Deactivate();
    }
    void SetPosition() 
    {
        Debug.Log("projectile. mouse posiiton");
        
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;
  
    }
}
