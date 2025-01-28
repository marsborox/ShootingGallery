using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

using static UnityEngine.GraphicsBuffer;

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
    TargetMovement targetMovement;
    TargetHealth targetHealth;
    [SerializeField] GameObject player;
    // Start is called before the first frame update

    public IObjectPool<Target> targetPool;//reference to targetMovement
    public IObjectPool<Target> targetPoolInTarget { set => targetPool = value; }

    //[SerializeField] GameObject scoreObject;
    private void Awake()
    {
        score=FindObjectOfType<Score>();
        //trajectoryConfigCollection = FindObjectOfType<TrajectoryConfigCollection>();for some reason wont work
        rigidBody2D = GetComponent<Rigidbody2D>();
        targetMovement = GetComponent<TargetMovement>();
        targetHealth = GetComponent<TargetHealth>();
    }
 
    private void OnEnable()
    {
        Respawn();
        targetMovement.trajectoryIndex = targetMovement.trajectoryConfigCollection.ReturnRandomConfig();//must be that method random
        targetMovement.RestartRoute();
    }
    void Respawn()
    {
        alive = true;
        targetMovement.RestartRoute();
        SetGravity(aliveGravity);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
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
        targetMovement.trajectoryConfigCollection= cfgCollection;
        if (targetMovement.trajectoryConfigCollection = null)
        {
            Debug.Log("target.cfgColelction null");
        }
    }

}
