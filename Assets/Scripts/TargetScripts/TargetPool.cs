using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

using static UnityEngine.GraphicsBuffer;

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
        //Debug.Log("targetPool. trajectoryConfigCollection is: " +  (trajectoryConfigCollection == null ? "NULL": "NOT NULL")) ;
    }
    Target CreateTarget()
    {
        //Debug.Log("TargetPool. Creating Target");
        Target target = Instantiate(targetPrefab);
        //target.Initialize();

        target.targetPoolInTarget = targetPoolPool;
        //Debug.Log("targetPool.trajectoryConfigCollection is  " + (trajectoryConfigCollection != null ? "NULL" : "NOTNULL"));
        //target.SetTrajectoryConfingCollection(this.gameObject.GetComponent<TrajectoryConfigCollection>());
        /*
        Debug.Log("targetPool setting traectory cfg ocllection");
        if (this.GetComponent<TrajectoryConfigCollection>() != null)
        {
            Debug.Log("targetPool trajecotry cfg collection is not null");
        }
        if (target.GetComponent<TargetMovement>() != null) 
        {
            Debug.Log("targetPool target.GetComponent<TargetMovement>() is not null ");
        }
        if (target.GetComponent<TargetMovement>().trajectoryConfigCollection != null)
        {
            Debug.Log("targetPool target.GetComponent<TargetMovement>().trajectoryConfigCollection is not null ");
        }*/
        //fucking bullshit why?????
        //target.gameObject.GetComponent<TargetMovement>().trajectoryConfigCollection=this.GetComponent<TrajectoryConfigCollection>();//this works
        //target.targetMovement.trajectoryConfigCollection = trajectoryConfigCollection/*this.GetComponent<TrajectoryConfigCollection>()*/;//**** this is correct
        //target.SetTrajectoryConfingCollection(this.GetComponent<TrajectoryConfigCollection>());//*** this doesnt
        //Debug.Log("targetPool. target.trajectory cfg is:"+ (target.GetComponent<TargetMovement>().trajectoryConfigCollection==null? "NULL" : "NOTNULL"));
        return target;
    }

    void OnReleaseToPool(Target target)
    {
        target.gameObject.SetActive(false);
        target.alive = false;
    }
    public void OnGetFromPool(Target target)
    {
        target.gameObject.SetActive(true);
    }
    private void OnDestroyTarget(Target target)
    {
        Destroy(target.gameObject);
    }
    /*
    void SetRandomTrajectory(Target target)
    {//will be used on get from pool
        target.trajectoryIndex = Random.Range(0, trajectoryConfigCollection.configList.Count - 1);
    }*/
}
