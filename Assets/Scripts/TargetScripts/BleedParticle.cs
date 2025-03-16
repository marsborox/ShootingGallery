using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BleedParticle : MonoBehaviour
{
        ParticleSystem particleSystem;
        // deactivate after delay
        [SerializeField] private float timeoutDelay = 3f;

        private IObjectPool<BleedParticle> objectPoolPrivate;

        // public property to give the projectile a reference to its ObjectPool
        public IObjectPool<BleedParticle> bleedObjectPoolPublic { set => objectPoolPrivate = value; }

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    public void Deactivate()
        {//this method is mabye not needed?
            objectPoolPrivate.Release(this); 
        }


}
