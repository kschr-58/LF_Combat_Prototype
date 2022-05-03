using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXAutoDestroy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float destroyDelay;

    private void Update()
    {
        if (!_particleSystem.isEmitting) Destroy(gameObject, destroyDelay);
    }
}
