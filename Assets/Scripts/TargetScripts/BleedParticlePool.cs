using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BleedParticlePool : MonoBehaviour
{
    Target target;
    // deactivate after delay
    [SerializeField] GameObject bleedParticle;

    // stack-based ObjectPool available with Unity 2021 and above
    public IObjectPool<GameObject> bleedObjectPoolPublic;

    // throw an exception if we try to return an existing item, already in the pool
    [SerializeField] private bool collectionCheck = true;

    // extra options to control the pool capacity and maximum size
    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxSize = 100;

    private void Awake()
    {
            bleedObjectPoolPublic = new ObjectPool<GameObject>(CreateParticle,
            OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
            collectionCheck, defaultCapacity, maxSize);
    }

    private void Start()
    {

        TestParticleSpawn();
    }
    void TestParticleSpawn()
    {
        GameObject particle = Instantiate(bleedParticle);
        Instantiate(particle);
        Debug.Log("bleedParticlePool particle created - test");
    }

    // invoked when creating an item to populate the object pool
    private GameObject CreateParticle()
    {
        Debug.Log("bleedParticlePool particle created");

        GameObject bleedParticleInstance = Instantiate(bleedParticle.gameObject);
        bleedParticleInstance.GetComponent<BleedParticle>().bleedObjectPoolPublic = bleedObjectPoolPublic;
            
        return bleedParticleInstance;
    }
    // invoked when retrieving the next item from the object pool
    public void OnGetFromPool(GameObject pooledObject)
    {
        pooledObject.gameObject.SetActive(true);

        pooledObject.transform.position = target.transform.position;
    }

    // invoked when returning an item to the object pool
    private void OnReleaseToPool(GameObject pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
    private void OnDestroyPooledObject(GameObject pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

    private void FixedUpdate()
    {


    }
    public void SpawnBleedParticle(Target inputTarget)
    { 
        target = inputTarget;
        bleedObjectPoolPublic.Get();
    }
}
