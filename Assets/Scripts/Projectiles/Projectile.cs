using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [SerializeField] float dispersion = 0;
    int damage = 10;
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
        Target target = other.gameObject.GetComponent<Target>();
        if (target !=null)
        {
            Debug.Log("projectile. OnTrigger");
            //other.gameObject.GetComponent<Target>().Die();
            target.targetHealth.TakeDamage(damage);

            //Do Damage
            //Debug.Log("projectile.Doing Le Damage");
            target = null;
        }
        
    }
    private void OnEnable()
    {
        SetPosition();
        StartCoroutine(SpawnRoutine());
        StartCoroutine(ColliderShutdownRoutine());
        collider.enabled = true;
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
    IEnumerator ColliderShutdownRoutine()
    {
        yield return new WaitForSecondsRealtime(0.02f);
        //yield return new WaitForEndOfFrame();
        collider.enabled = false;
    }
    public virtual void SetPosition() 
    {
        Debug.Log("projectile. mouse posiiton");
        Vector2 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = pz;
    }

    public Vector2 Disperze(Vector2 inputVector)
    {
        float moveDistance=Random.Range(0,dispersion);

        Debug.Log("projectile. dispersion distance = "+moveDistance);
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        Vector2 newPosition = inputVector + randomDirection * moveDistance;
        return newPosition;
    }
}
