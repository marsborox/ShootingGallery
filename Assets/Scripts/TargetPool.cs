using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPool : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;


    TrajectoryConfigCollection trajectoryConfigCollection;
    private void Awake()
    {
        trajectoryConfigCollection=GetComponent<TrajectoryConfigCollection>();
    }
    private void Start()
    {


    }

    void SpawnTarget()
    {
        var target = Instantiate(targetPrefab);
        SetRandomTrajectory(target);
    }
    void SetRandomTrajectory(GameObject target)
    {//will be used on get from pool
        target.GetComponent<Target>().trajectoryIndex = Random.Range(0, trajectoryConfigCollection.configList.Count - 1);
    }
}
