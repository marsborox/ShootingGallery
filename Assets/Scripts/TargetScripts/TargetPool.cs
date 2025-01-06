using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TargetPool : MonoBehaviour
{
    [SerializeField] Target targetPrefab;


    TrajectoryConfigCollection trajectoryConfigCollection;

    public IObjectPool<Target> targetPoolPool;
    [SerializeField] private bool targetPoolCollectionCheck = true;
    
    [SerializeField] private int targetPoolDefaultCapacity = 20;
    [SerializeField] private int targetPoolMaxSize = 100;

    private void Awake()
    {
        trajectoryConfigCollection=GetComponent<TrajectoryConfigCollection>();
        targetPoolPool = new ObjectPool<Target>(CreateTarget,OnGetFromPool,OnReleaseToPool, OnDestroyTarget, targetPoolCollectionCheck, targetPoolDefaultCapacity, targetPoolMaxSize);
        
    }
    private void Start()
    {
       

    }

    Target CreateTarget()
    {
        Target target = Instantiate(targetPrefab);
        target.targetPoolInTarget = targetPoolPool;

        target.trajectoryConfigCollection =  this.gameObject.GetComponent<TrajectoryConfigCollection>();
        return target;

    }
    void OnReleaseToPool(Target target)
    { 
        target.gameObject.SetActive(false);
        target.alive = false;
    }
    public void OnGetFromPool(Target target)
    {
        
        target.trajectoryIndex = trajectoryConfigCollection.ReturnRandomConfig();//must be that method random
        target.RestartRoute();
        target.gameObject.SetActive(true);
    }
    
    private void OnDestroyTarget(Target target)
    {
        Destroy(target.gameObject);
    }
    void SetRandomTrajectory(Target target)
    {//will be used on get from pool
        target/*.GetComponent<Target>()*/.trajectoryIndex = Random.Range(0, trajectoryConfigCollection.configList.Count - 1);
    }
}
