using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{

    public bool alive = true;
    float deadGravity = 3f;//10 is good
    float aliveGravity = 0f;
    int targetScore = 1;

    string floorTag = "Floor";
    string projectileTag = "Projectile";
    //public GameObject trajectoryPrefab;
    public int SO_index{ private get; set; }

    
    Score score;
    public Rigidbody2D rigidBody2D;
    public TargetMovement targetMovement;
    public TargetHealth targetHealth;
    [SerializeField] GameObject player;
    [SerializeField] GameObject visualObject;
    // Start is called before the first frame update

    public IObjectPool<Target> targetPool;//reference to targetMovement
    public IObjectPool<Target> targetPoolInTarget { set => targetPool = value; }

    //[SerializeField] GameObject scoreObject;
    private void Awake()
    {
        //Debug.Log("target.Initialize has run");
        score = FindObjectOfType<Score>();
        //trajectoryConfigCollection = FindObjectOfType<TrajectoryConfigCollection>();for some reason wont work
        rigidBody2D = GetComponentInChildren<Rigidbody2D>();
        targetHealth = GetComponent<TargetHealth>();
        targetMovement = GetComponent<TargetMovement>();
        //Debug.Log("targetMovement assigned in Initialize: " + (targetMovement == null ? "null" : "set"));
        //Debug.Log("targetHealth assigned in Initialize: " + (targetHealth == null ? "null" : "set"));
        //Debug.Log("rigidBody2D assigned in Initialize: " + (rigidBody2D == null ? "null" : "set"));
        
    }
    private void Update()
    {

    }
    private void Start()
    {
    }

    private void OnEnable()
    {
        /*
        Debug.Log("target. Enabled");

        Debug.Log("targetMovement assigned in Initialize works in enabled: " + (targetMovement == null ? "null" : "set"));
        Debug.Log("targetHealth assigned in Initialize works in enabled: " + (targetHealth == null ? "null" : "set"));

        //targetMovement.StartRandomRoute();
        //targetMovement.RestartRoute();
        Debug.Log("target.targetMovement. trajectoryIndex is " + ( targetMovement.trajectoryIndex != null ? "yes" :"no"));
        */
        Respawn();
        //Debug.Log("random route Config number: " + targetMovement.trajectoryConfigCollection.ReturnRandomConfig());
        
    }
    void Respawn()
    {
        rigidBody2D.isKinematic= true;
        //Debug.Log("target. Respawned");
        alive = true;
        targetMovement.RestartRoute();
        //Debug.Log("target. routeRestarted");
        SetGravity(aliveGravity);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        ResetVisualModelAxis();
        //this.transform.position
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!alive && other.tag == floorTag)
        {
            targetPool.Release(this);
        }
        if (alive && other.tag==projectileTag)
        {
            Die();
        }
        //if floor collider hits this object
        /*{
        Deactivate
            }*/
    }

    public void TakeDamage(int damage)
    {
        targetHealth.TakeDamage(damage);
    }
    public void Die()
    {
        score.AddScore(targetScore);
        //falling down
        alive = false;
        rigidBody2D.isKinematic = false;
        SetGravity(deadGravity);
        //set direction of kick
        //targetMovement.Throw();
        StartCoroutine(DespawnRoutine());

    }
    IEnumerator DespawnRoutine()
    {
        yield return new WaitForSeconds(3f);
        targetPool.Release(this);//remove when floor is introduced - whole routine
    }
    void SetGravity(float inputGravityScale)
    {
        this.rigidBody2D.gravityScale = inputGravityScale;
    }
    void DeathMove()
    {
        
    }
    
    public void SetTrajectoryConfingCollection(TrajectoryConfigCollection cfgCollection)
    {
        //Debug.Log("target.SetTrajectoryConfigColelction is running");
        //Debug.Log("target.targetMovement is " + (targetMovement != null ? "NOT NULL" : "NULL"));
        //Debug.Log("target.cfgCollection is " + (cfgCollection != null ? "NOT NULL" : "NULL"));
        //Debug.Log("target.targetMovement.trajectoryConfigCollection is " + (targetMovement.trajectoryConfigCollection != null ? "NOT NULL" : "NULL"));

        
        targetMovement.trajectoryConfigCollection= cfgCollection;// this is broken*********************************
        if (targetMovement.trajectoryConfigCollection = null)
        {
            //Debug.Log("target.cfgColelction null");
        }
        //Debug.Log("target.targetMovement.trajectoryConfigCollection end of Method is " + (targetMovement.trajectoryConfigCollection != null ? "NOT NULL" : "NULL"));
    }
    public void OnKill()
    {
        rigidBody2D.isKinematic = true;
    }
    void ResetVisualModelAxis()
    {
        visualObject.transform.localPosition = new Vector2(0,0);
    }
}
