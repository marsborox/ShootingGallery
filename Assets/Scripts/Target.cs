using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Target : MonoBehaviour
{
    float movementSpeed = 0.01f;
    public int trajectoryIndex { get ;  set; }
    public int waypointIndexGlobal = 1;




    public GameObject trajectoryPrefab;
    public int SO_index{ private get; set; }

    public Transform nextWaypoint;

    TrajectoryConfigCollection trajectoryConfigCollection;
    // Start is called before the first frame update

    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        CheckWaypoint();
        Move();
        */
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
    int GetMeNextWaypointIndex()
    {
        if (trajectoryPrefab.transform.GetChild(waypointIndexGlobal + 1) == null)
        {
            transform.position = trajectoryPrefab.transform.GetChild(0).position;
            return 1;
        }
        else
        {
            return waypointIndexGlobal ++;
        }
    }
    void ArrivedToWaypoint()
    {
        if (trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList.Count-1==waypointIndexGlobal)
        {
            RestartRoute();
        }
        else
        {
            GenerateNextWaypointTransform(trajectoryIndex,waypointIndexGlobal);
        }
    }
    void RestartRoute()
    {
        waypointIndexGlobal=0;
        transform.position = trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[0].position;
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

        waypointIndexGlobal++;
        return trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex];
    }

}
