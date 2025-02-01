using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
    // Start is called before the first frame update

    public IObjectPool<Target> targetPool;//reference to targetMovement
    public IObjectPool<Target> targetPoolInTarget { set => targetPool = value; }

    //[SerializeField] GameObject scoreObject;
    private void Awake()
    {
        
    }
    private void Start()
    {
    }
    public void Initialize()
    {
        Debug.Log("target.Initialize has run");
        score = FindObjectOfType<Score>();
        //trajectoryConfigCollection = FindObjectOfType<TrajectoryConfigCollection>();for some reason wont work
        rigidBody2D = GetComponent<Rigidbody2D>();
        targetHealth = GetComponent<TargetHealth>();
        targetMovement = GetComponent<TargetMovement>();
        Debug.Log("targetMovement assigned in Initialize: " + (targetMovement != null ? "YES" : "NO"));

    }
    private void OnEnable()
    {
        Debug.Log("target. Enabled");
        targetMovement.trajectoryIndex = targetMovement.trajectoryConfigCollection.ReturnRandomConfig();//must be that method random
        Respawn();
        //targetMovement.RestartRoute();
    }
    void Respawn()
    {
        //Debug.Log("target. Respawned");
        alive = true;
        targetMovement.RestartRoute();
        //Debug.Log("target. routeRestarted");
        SetGravity(aliveGravity);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
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
        alive = false;
        //falling down
        SetGravity(deadGravity);
        //set direction of kick
        targetMovement.Throw();
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

    
    public void SetTrajectoryConfingCollection(TrajectoryConfigCollection cfgCollection)
    {
        Debug.Log("target.SetTrajectoryConfigColelction is running");
        Debug.Log("target.targetMovement is " + (targetMovement != null ? "NOT NULL" : "NULL"));
        Debug.Log("target.cfgCollection is " + (cfgCollection != null ? "NOT NULL" : "NULL"));
        Debug.Log("target.targetMovement.trajectoryConfigCollection is " + (targetMovement.trajectoryConfigCollection != null ? "NOT NULL" : "NULL"));

        
        targetMovement.trajectoryConfigCollection= cfgCollection;// this is broken*********************************
        if (targetMovement.trajectoryConfigCollection = null)
        {
            Debug.Log("target.cfgColelction null");
        }
        Debug.Log("target.targetMovement.trajectoryConfigCollection end of Method is " + (targetMovement.trajectoryConfigCollection != null ? "NOT NULL" : "NULL"));
    }

}
