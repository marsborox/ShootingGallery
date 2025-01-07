using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    Rigidbody2D rigidBody2D;

    
    float movementSpeed = 0.01f;//0.01-0.1 ok
    [SerializeField] public int trajectoryIndex;
    [SerializeField] int waypointIndex;

    float deadGravity = 10f;//10 is good
    float aliveGravity = 0f;

    string floorTag = "Floor";
    string projectileTag = "Projectile";
    public bool alive { private get; set; } = true;
    //public GameObject trajectoryPrefab;
    public int SO_index{ private get; set; }
    int targetScore = 1;

    private Score score;

    
    public Transform nextWaypoint;
    

    public TrajectoryConfigCollection trajectoryConfigCollection { private get; set; }
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    
    public IObjectPool<Target> targetPool { private get; set; }
    public IObjectPool<Target> targetPoolInTarget { set => targetPool = value; }

    
    //[SerializeField] GameObject scoreObject;
    private void Awake()
    {
        score=FindObjectOfType<Score>();
        //trajectoryConfigCollection = FindObjectOfType<TrajectoryConfigCollection>();for some reason wont work

        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        waypointIndex = 0;
        RestartRoute();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (alive) 
        { 
            CheckWaypoint(); 
            Move(); 
        }
        else return;
        
        
    }
    private void OnEnable()
    {
        Respawn();
        
    }
    private void Move()
    {
        Debug.Log("target.Moving");
        transform.position= Vector2.MoveTowards(transform.position,nextWaypoint.position,movementSpeed);// *Time.deltaTime
        //Debug.Log(Vector2.Distance(transform.position, nextWaypoint.transform.position));
    }

    void CheckWaypoint()
    {
        //may be outdated
        //for some reasin this is broken it returns object even it should not
        //in distance +/- less than 0.4 but does not print the waypoint reached
        //Debug.Log("target.Checking waypoint");
        
        if(transform.position== nextWaypoint.transform.position)
        {
            ArrivedToWaypoint();
        }
    }

    void ArrivedToWaypoint()
    {
        //Debug.Log("target.waypointIndex&");

        int maxWaypointIndex = trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList.Count-1;
        //Debug.Log("target.max index of waypoint= " + maxWaypointIndex);
        //Debug.Log("target.waypoint Index is= "+waypointIndex);
        
        if (maxWaypointIndex == waypointIndex)
        {
            waypointIndex = 0;
            
            targetPool.Release(this);
            //Debug.Log("target.trajectoryWaypointTransformList.Count = " + trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList.Count);
            //RestartRoute();
        }
        else
        {
            //when we reach waypoint 
            //Debug.Log("target.Generating next index");
            nextWaypoint =GenerateNextWaypointTransform();
        }
    }
    public void RestartRoute()
    {
        waypointIndex = 0;
        //Debug.Log("target.display indexes = "+ trajectoryIndex + " " + waypointIndex_GlobalVar);

        var pulledTransform = trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex].transform;
        if (pulledTransform == null)
        {
            Debug.Log("target.pulledTransform = Null");
        }
        //transform.position = ReturnWaypoont(trajectoryIndex, waypointIndex).position;
        //nextWaypoint = ReturnWaypoont(trajectoryIndex, waypointIndex);
        
        else
        {
            transform.position = trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex].transform.position;
            nextWaypoint = GenerateNextWaypointTransform();
            
        }
    }

        Transform ReturnWaypoont(int i, int j)
        {

            //return trajectoryConfigCollection.configList[i].trajectoryWaypointTransformList[j].transform;
            if (trajectoryConfigCollection == null)
            {
                Debug.LogError("Collection is null. Make sure it is initialized before calling this method.");
                return null;
            }

            // Ensure the index i is within bounds of list1
            if (i < 0 || i >= trajectoryConfigCollection.configList.Count)
            {
                Debug.LogError("Index i is out of range.");
                return null;
            }

            // Ensure the index j is within bounds of the GameObject list in the selected ScriptableObject
            var selectedContainer = trajectoryConfigCollection.configList[i];
            if (selectedContainer == null)
            {
                Debug.LogError("Selected container is null.");
                return null;
            }
            if (j < 0 || j >= selectedContainer.trajectoryWaypointTransformList.Count)
            {
                Debug.LogError("Index j is out of range.");
                return null;
            }

            // Return the Transform of the specified GameObject
            return selectedContainer.trajectoryWaypointTransformList[j].transform;
        }

        Transform GenerateNextWaypointTransform()
        {
            waypointIndex++;
            return trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex].transform;
        }
    void Respawn()
    {
        alive = true;
        RestartRoute();
        SetGravity(aliveGravity);
        this.transform.rotation=Quaternion.Euler(0,0,0);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (!alive && other.tag == floorTag)
        {
            targetPool.Release(this);
        }
        if (alive && other.tag==projectileTag)
        {
            TakeDamage();
        }
        //if floor collider hits this object
        /*{
        Deactivate
            }*/
    }
    public void TakeDamage()
    {

        Die();
    }
    IEnumerator DespawnRoutine()
    {
        yield return new WaitForSeconds(3f);
        targetPool.Release(this);//remove when floor is introduced - whole routine
    }
    public void Die()
    {

        score.AddScore(targetScore);
        //falling down
        alive = false;
        SetGravity(deadGravity);
        Throw();
        StartCoroutine(DespawnRoutine());
        
    }
    void SetGravity(float inputGravityScale)
    {
        this.rigidBody2D.gravityScale = inputGravityScale;
    }
    void SetRandomDirection()
    { 
        
    }
    private void Throw()
    {
        transform.eulerAngles = new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), transform.eulerAngles.z);

        float speed = 50;
        //rigidBody2D.isKinematic = false;
        Vector3 force = transform.forward;
        force = new Vector3(force.x, force.y, 1);
        rigidBody2D.AddForce(force * speed);
    }
    private void RandomThrow()
    {
        transform.eulerAngles = new Vector2(transform.eulerAngles.x, UnityEngine.Random.Range(0, 360));

        float speed = 10;
        rigidBody2D.isKinematic = false;
        Vector3 force = transform.forward;
        force = new Vector2(force.x, 1);
        rigidBody2D.AddForce(force * speed);
    }
}
