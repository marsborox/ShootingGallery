using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    TargetPool targetPool;

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
        }
    }

    float RandomRespawnTime()
    {
        return Random.Range(0, MaxRespawnTime);
    }
    IEnumerator SpawnTargetEveryINPUTseconds()
    {
        spawningInProgress = true;
        Debug.Log("WaitingForSpawn");
        yield return new WaitForSeconds(RandomRespawnTime());
        Debug.Log("DoingSpawn");
        targetPool.targetPoolPool.Get();
        spawningInProgress = false;
    }
}
