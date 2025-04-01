using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    TargetPool targetPool;
    public float MaxRespawnTime = 0.2f;
    bool spawningInProgress = false;

    private void Awake()
    {
        targetPool = GetComponent<TargetPool>();
    }
    private void Start()
    {
        //targetPool.targetPoolPool.Get();
    }
    
    private void Update()
    {
        if (!spawningInProgress)
        {
            //SpawnOneEvery3Seconds();
            StartCoroutine(SpawnTargetEveryINPUTseconds());// ***** this one is real
            //Debug.Log("targetSpawner.spawning target");
        }
    }

    IEnumerator SpawnTargetEveryINPUTseconds()
    {
        spawningInProgress = true;
        //Debug.Log("targetSpawner.WaitingForSpawn");
        yield return new WaitForSeconds(RandomRespawnTime());
        //Debug.Log("targetSpawner.DoingSpawn");
        targetPool.targetPoolPool.Get();
        spawningInProgress = false;
        //fjsdlkafjlkdsajflkdsafstest remove
    }
    float RandomRespawnTime()
    {
        return Random.Range(0, MaxRespawnTime);
    }
    IEnumerator SpawnOneEvery3Seconds()
    {
        spawningInProgress = true;
        //Debug.Log("targetSpawner.WaitingForSpawn");
        yield return new WaitForSeconds(3f);
        //Debug.Log("targetSpawner.DoingSpawn");
        targetPool.targetPoolPool.Get();
        spawningInProgress = false;
    }
    public void SpawnOneTarget()
    {
        targetPool.targetPoolPool.Get();
    }
}
