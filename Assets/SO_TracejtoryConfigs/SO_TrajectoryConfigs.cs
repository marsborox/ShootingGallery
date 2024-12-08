using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TrajectoryConfig", fileName = "New Trajectory Config")]
public class SO_TrajectoryConfigs : ScriptableObject
{
    [SerializeField] Transform trajectoryPrefab;

    public List<Transform> trajectoryWaypointTransformList;
    void Start()
    { 
        //trajectoryTransform = new List();
        trajectoryWaypointTransformList=GetWaypoints();

    }
    public Transform GetStartingWapoint()
    {
        return trajectoryPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    { 
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in trajectoryPrefab) 
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

}
