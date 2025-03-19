using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [SerializeField] float dispersion = 0;
    int damage = 0;
    Collider2D collider;
    
    public Shooting shooting;
    private IObjectPool<Projectile> projectilePoolPrivate;
    public IObjectPool<Projectile> projectilePoolPublic { set => projectilePoolPrivate = value; }

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        shooting = FindObjectOfType<Shooting>();
    }
    private void Start()
    {

        collider.enabled = false;
        //Debug.Log("projectile.Projectile spawned, starting routine");
    }
    //int damage = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Target target = other.gameObject.GetComponentInParent<Target>();
        if (target !=null)
        {
            //Debug.Log("projectile. OnTrigger");
            //other.gameObject.GetComponent<Target>().Die();
            target.targetHealth.TakeDamage(damage);

            //Do Damage
            //Debug.Log("projectile.Doing Le Damage");
            target = null;
        }
        
    }
    private void OnEnable()
    {
        //if (shooting == null) { Debug.Log("projectile. shooting null"); }
        SetDamage(shooting.currentWeapon.weaponDamage);
        SetPosition();
        RotateProjectile();
        StartCoroutine(DeSpawnRoutine());
        StartCoroutine(ColliderShutdownRoutine());
        collider.enabled = true;

    }
    void RotateProjectile()
    {
        
        float random = Random.Range(0, 360);
        transform.Rotate(0,0,random,Space.World);
        transform.eulerAngles = new Vector3(0, 0, random);

    }
    public void SetShootingOnCreate(Shooting passedShoting)
    { 
        shooting = passedShoting;
    }
    IEnumerator DeSpawnRoutine()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        //Debug.Log("projectile.Projectile despawning");
        projectilePoolPrivate.Release(this);
    }
 
    IEnumerator ColliderShutdownRoutine()
    {
        yield return new WaitForSecondsRealtime(0.02f);
        //yield return new WaitForEndOfFrame();
        collider.enabled = false;

    }
    public virtual void SetPosition() 
    {
        //Debug.Log("projectile. mouse posiiton");
        Vector2 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = pz;
    }
    public void SetDamage(int insertedDamage)
    {
        damage = insertedDamage;
    }
    public Vector2 Disperze(Vector2 inputVector)
    {
        float moveDistance=Random.Range(0,dispersion);

        //Debug.Log("projectile. dispersion distance = "+moveDistance);
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        Vector2 newPosition = inputVector + randomDirection * moveDistance;
        return newPosition;
    }
}
