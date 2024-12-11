using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Target : MonoBehaviour
{
    float movementSpeed = 0.01f;
    [SerializeField] public int trajectoryIndex;
    [SerializeField] public int waypointIndex_GlobalVar=0;

    string floorTag = "Floor";

    public bool dead { private get; set; } = false;

    //public GameObject trajectoryPrefab;
    public int SO_index{ private get; set; }

    public Transform nextWaypoint;

    public TrajectoryConfigCollection trajectoryConfigCollection { private get; set; }
    // Start is called before the first frame update
    
    private IObjectPool<Target> targetPool;
    public IObjectPool<Target> targetPoolInTarget { set => targetPool = value; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckWaypoint();
        Move();
        
    }
    private void OnEnable()
    {
        RestartRoute();
    }
    private void Move()
    {
        transform.position= Vector2.MoveTowards(transform.position,nextWaypoint.position,movementSpeed*Time.deltaTime);
    }

    void CheckWaypoint()
    {
        if (Vector2.Distance(transform.position, nextWaypoint.transform.position) < 0.1)
        {
            Debug.Log("waypoint reached");

            ArrivedToWaypoint();
            //nextWaypoint = GenerateNextWaypointTransform(trajectoryIndex,waypointIndexGlobal);

            //nextWaypoint = trajectoryPrefab.transform.GetChild(GetMeNextWaypointIndex());
        }
    }
    /*
    int GetMeNextWaypointIndex()
    {//this is discontinued method that ignores SOs
        if (trajectoryPrefab.transform.GetChild(waypointIndexGlobal + 1) == null)
        {
            transform.position = trajectoryPrefab.transform.GetChild(0).position;
            return 1;
        }
        else
        {
            return waypointIndexGlobal ++;
        }
    }*/
    void ArrivedToWaypoint()
    {
        if (trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList.Count - 1==waypointIndex_GlobalVar)
        {
            Debug.Log("target.trajectoryWaypointTransformList.Count = " + trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList.Count);
            RestartRoute();
        }
        else
        {
            GenerateNextWaypointTransform(trajectoryIndex,waypointIndex_GlobalVar);
        }
    }
    public void RestartRoute()
    {
        waypointIndex_GlobalVar=0;
        transform.position = trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex_GlobalVar].position;
        nextWaypoint = trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex_GlobalVar+1];
    }

    Transform GenerateNextWaypointTransform(int trajectoryIndex,int waypointIndex)
    {
        /*
        Transform returnTransform=null;
        
        returnTransform = trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex];
        return returnTransform;
        */
        //input int "index from configs", int waypointIndex 
        //waypoint at targetPool.<List>TrajectoryConfigs.[trajectoryIndex].<List>Trajectory[waypointIndex]
        // waypointIndex++
        //return waypoint

        waypointIndex_GlobalVar++;
        return trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex];
    }
    public void Die()
    {
        //falling down
        dead = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (dead &&other.tag == floorTag)
        {
            Deactivate();
        }
        //if floor collider hits this object
        /*{
        Deactivate
            }*/
    }
    public void Deactivate()
    {
        targetPool.Release(this);
    }
}
