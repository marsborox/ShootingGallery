using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BleedParticle : MonoBehaviour
{
        ParticleSystem particleSystem;


        private IObjectPool<GameObject> objectPoolPrivate;

        // public property to give the projectile a reference to its ObjectPool
        public IObjectPool<GameObject> bleedObjectPoolPublic { set => objectPoolPrivate = value; }

        private void Awake()
        {
            particleSystem = GetComponent<ParticleSystem>();
        }
        private void Start()
        {
        
        }
        private void OnEnable()
        {
            DespawnRoutine();
        }
        public IEnumerable DespawnRoutine()
        { 
            float waitTime = particleSystem.main.duration + particleSystem.main.startLifetime.constantMax;
            yield return new WaitForSeconds (waitTime);
            Deactivate();
        }    
        public void Deactivate()
            {//this method is mabye not needed?
                objectPoolPrivate.Release(gameObject); 
            }

}
