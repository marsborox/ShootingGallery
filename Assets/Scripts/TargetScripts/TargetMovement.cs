using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class TargetMovement : MonoBehaviour
{
    //public bool alive = true;
    [SerializeField] int waypointIndex;
    public bool directionIsLeft;
    float throwSpeed = 500f;
    float movementSpeed = 5f;//0.01-0.1 ok //0.02 os fastish but ok// only without Time.deltaTime
    public int trajectoryIndex;
    // Start is called before the first frame update
    public Transform nextWaypoint;
    public TrajectoryConfigCollection trajectoryConfigCollection;
    Target target;


    private void Awake()
    {
        target = GetComponent<Target>();
        trajectoryConfigCollection = FindObjectOfType<TrajectoryConfigCollection>();
    }
    void Start()
    {
        waypointIndex = 0;
        RestartRoute();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (target.alive)
        {
            CheckWaypoint();
            Move();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, nextWaypoint.position, movementSpeed * Time.deltaTime);
        }

    }
    private void OnEnable()
    {
        
    }
    private void Move()
    {

        float delta = movementSpeed * Time.deltaTime;
        //Debug.Log("target.Moving");
        transform.position = Vector2.MoveTowards(transform.position, nextWaypoint.position, delta);// *Time.deltaTime
        //Debug.Log(Vector2.Distance(transform.position, nextWaypoint.transform.position));
    }

    void CheckWaypoint()
    {
        //may be outdated
        //for some reasin this is broken it returns object even it should not
        //in distance +/- less than 0.4 but does not print the waypoint reached
        //Debug.Log("target.Checking waypoint");

        if (transform.position == nextWaypoint.transform.position)
        {
            ArrivedToWaypoint();
        }
    }

    void ArrivedToWaypoint()
    {
        //Debug.Log("target.waypointIndex&");

        int maxWaypointIndex = trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList.Count - 1;
        //Debug.Log("target.max index of waypoint= " + maxWaypointIndex);
        //Debug.Log("target.waypoint Index is= "+waypointIndex);

        if (maxWaypointIndex == waypointIndex)
        {
            waypointIndex = 0;

            target.targetPool.Release(target);
            //Debug.Log("target.trajectoryWaypointTransformList.Count = " + trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList.Count);
            //RestartRoute();
        }
        else
        {
            //when we reach waypoint 
            //Debug.Log("target.Generating next index");
            nextWaypoint = GenerateNextWaypointTransform();
        }
    }
    public void StartRandomRoute()
    {
        //Debug.Log(".targetMovement. trajectoryConfigCollection is null? " + (trajectoryConfigCollection == null ? "yes" : "no"));
        //Debug.Log(".targetMovement. trajectoryIndex pre assignment is null? " + (trajectoryIndex == null ? "yes" : "no"));
        trajectoryIndex = trajectoryConfigCollection.ReturnRandomConfig();//** this is somewhat broken but method is working like trajectorz index is fcked up
        //so even on awake it gets reference it returns null
        //Debug.Log(".targetMovement. trajectoryIndex post assignment is null? " + (trajectoryIndex == null ? "yes" : "no"));
        //Debug.Log("targetMovement. trajectory indes is: " + trajectoryIndex.ToString());
    }
    public void RestartRoute()
    {
        StartRandomRoute();
        //Debug.Log("targetMovement. RestartingRoute");
        waypointIndex = 0;
        //Debug.Log("target.display indexes = trajectory"+ trajectoryIndex + "waypoint " + waypointIndex);

        var pulledTransform = trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex].transform;
        if (pulledTransform == null)
        {
            //Debug.Log("targetMovement.pulledTransform = Null");
        }
        //transform.position = ReturnWaypoont(trajectoryIndex, waypointIndex).position;
        //nextWaypoint = ReturnWaypoont(trajectoryIndex, waypointIndex);

        else
        {
            //Debug.Log("targetMovement.pulledTransform != Null");
            transform.position = trajectoryConfigCollection.configList[trajectoryIndex].trajectoryWaypointTransformList[waypointIndex].transform.position;
            nextWaypoint = GenerateNextWaypointTransform();
            directionIsLeft = CheckDirection();
        }
    }

    bool CheckDirection()
    {
        if (transform.position.x > nextWaypoint.transform.position.x)
        {
            return true;
        }
        else return false;
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
    public void Throw()
    {
        //transform.eulerAngles = new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), transform.eulerAngles.z);

        //rigidBody2D.isKinematic = false;
        //Vector3 forceVector = transform.forward;
        /*Transform transformGameObject = transform.position;
        float xAxis = transform.position.x;*/
        /*
        float directionVectorX;
        if (directionIsLeft) { directionVectorX = nextWaypoint.transform.position.y; }


       
        Vector3 forceVector = new Vector3(nextWaypoint.transform.position.x, nextWaypoint.transform.position.y);
        target.rigidBody2D.AddForce(forceVector * throwSpeed);*/

        
        Vector2 direction = (nextWaypoint.transform.position-transform.position).normalized;

        target.rigidBody2D.velocity = direction*movementSpeed;
        

        //target.rigidBody2D.AddForce(nextWaypoint.transform.position * movementSpeed);
    }
}
