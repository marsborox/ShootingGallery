using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Particles : MonoBehaviour
{
    public class RevisedProjectile : MonoBehaviour
    {
        // deactivate after delay
        [SerializeField] BleedParticle projectilePrefab;

        // stack-based ObjectPool available with Unity 2021 and above
        private IObjectPool<BleedParticle> bleedObjectPoolPublic;

        // throw an exception if we try to return an existing item, already in the pool
        [SerializeField] private bool collectionCheck = true;

        // extra options to control the pool capacity and maximum size
        [SerializeField] private int defaultCapacity = 20;
        [SerializeField] private int maxSize = 100;

        private void Awake()
        {
            bleedObjectPoolPublic = new ObjectPool<BleedParticle>(CreateProjectile,
                OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
                collectionCheck, defaultCapacity, maxSize);
        }

        // invoked when creating an item to populate the object pool
        private BleedParticle CreateProjectile()
        {
            BleedParticle bleedParticleInstance = Instantiate(projectilePrefab);
            bleedParticleInstance.bleedObjectPoolPublic = bleedObjectPoolPublic;
            //other way if many classes are on object
            return bleedParticleInstance;
        }
        // invoked when retrieving the next item from the object pool
        private void OnGetFromPool(BleedParticle pooledObject)
        {
            pooledObject.gameObject.SetActive(true);
        }

        // invoked when returning an item to the object pool
        private void OnReleaseToPool(BleedParticle pooledObject)
        {
            pooledObject.gameObject.SetActive(false);
        }

        // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
        private void OnDestroyPooledObject(BleedParticle pooledObject)
        {
            Destroy(pooledObject.gameObject);
        }

        private void FixedUpdate()
        {


        }
    
    }
}
