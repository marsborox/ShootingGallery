using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    TargetPool targetPool;
    List<Target> targets = new List<Target>();
    float MaxRespawnTime = 2;
    bool spawningInProgress = false;

    private void Awake()
    {
        targetPool = GetComponent<TargetPool>();
    }
    private void Update()
    {
        
        if (!spawningInProgress)
        {
            StartCoroutine(SpawnTargetEveryINPUTseconds());
            //Debug.Log("targetSpawner.spawning target");
        }
    }

    float RandomRespawnTime()
    {
        return Random.Range(0, MaxRespawnTime);
    }
    IEnumerator SpawnTargetEveryINPUTseconds()
    {
        spawningInProgress = true;
        //Debug.Log("targetSpawner.WaitingForSpawn");
        yield return new WaitForSeconds(RandomRespawnTime());
        //Debug.Log("targetSpawner.DoingSpawn");
        targetPool.targetPoolPool.Get();

        spawningInProgress = false;
    }
}
