using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    float movementSpeed = 0.01f;
    [SerializeField] public int trajectoryIndex;
    [SerializeField] int waypointIndex;

    string floorTag = "Floor";

    public bool dead { private get; set; } = false;

    //public GameObject trajectoryPrefab;
    public int SO_index{ private get; set; }

    public Transform nextWaypoint;

    public TrajectoryConfigCollection trajectoryConfigCollection { private get; set; }
    // Start is called before the first frame update
    
    private IObjectPool<Target> targetPool;
    public IObjectPool<Target> targetPoolInTarget { set => targetPool = value; }
    private void Awake()
    {
        trajectoryConfigCollection = FindObjectOfType<TrajectoryConfigCollection>();
    }
    void Start()
    {
        waypointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckWaypoint();
        Move();
        
    }
    private void OnEnable()
    {
        //RestartRoute();
    }
    private void Move()
    {
        Debug.Log("target.Moving");
        transform.position= Vector2.MoveTowards(transform.position,nextWaypoint.position,movementSpeed);// *Time.deltaTime
        //Debug.Log(Vector2.Distance(transform.position, nextWaypoint.transform.position));
    }

    void CheckWaypoint()
    {
        //for some reasin this is broken it returns object even it should not
        //in distance +/- less than 0.4 but does not print the waypoint reached
        Debug.Log("target.checkingWaypoint");
        if (transform.position == null)
        {
            Debug.Log("target.nextWaypoint.transform.positio");    
        }
        if (transform.position == null)
        {
            Debug.Log("target.nextWaypoint.transform.positio");
        }
        Debug.Log(Vector2.Distance(transform.position, nextWaypoint.transform.position));


        if (Vector2.Distance(transform.position, nextWaypoint.transform.position) < 0.0001)
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
        if (trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList.Count - 1==waypointIndex)
        {
            Debug.Log("target.trajectoryWaypointTransformList.Count = " + trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList.Count);
            RestartRoute();
        }
        else
        {
            Debug.Log("target.Generating next index");
            GenerateNextWaypointTransform(trajectoryIndex);
        }
    }
    public void RestartRoute()
    {
        waypointIndex=0;
        //Debug.Log("target.display indexes = "+ trajectoryIndex + " " + waypointIndex_GlobalVar);

        /*var pulledTransform = trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex_GlobalVar].transform;
        if (pulledTransform == null)
        {
            Debug.Log("target.pulledTransform = Null");
        }*/
        //transform.position = ReturnWaypoont(trajectoryIndex, waypointIndex_GlobalVar).position;
         
        transform.position = trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex].transform.position;
        nextWaypoint = trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex+1].transform;
    }

    Transform ReturnWaypoont(int i, int j)
    {

        return trajectoryConfigCollection.configList[i].trajectoryWaypointTransformList[j].transform;
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

    Transform GenerateNextWaypointTransform(int trajectoryIndex)
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

        waypointIndex++;
        return trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex].transform;
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
