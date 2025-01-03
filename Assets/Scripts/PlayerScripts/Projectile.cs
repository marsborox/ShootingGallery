using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    Collider2D collider;
    private IObjectPool<Projectile> projectilePoolPrivate;
    public IObjectPool<Projectile> projectilePoolPublic { set => projectilePoolPrivate = value; }
    private void Awake()
    {
        
        collider = GetComponent<Collider2D>();
    }
    private void Start()
    {
        collider.enabled = false;
        //Debug.Log("projectile.Projectile spawned, starting routine");
    }
    //int damage = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Target>())
        {
            //other.gameObject.GetComponent<Target>().Die();

            other.gameObject.GetComponent<Target>().TakeDamage();
            //Do Damage
            //Debug.Log("projectile.Doing Le Damage");
        }
    }
    private void OnEnable()
    {
        SetPosition();
        StartCoroutine(SpawnRoutine());
        collider.enabled = true;
        collider.enabled = false;
    }

    public void Deactivate()
    {
        projectilePoolPrivate.Release(this);
    }
    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSecondsRealtime(0.4f);
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
