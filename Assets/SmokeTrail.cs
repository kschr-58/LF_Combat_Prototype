using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeTrail : MonoBehaviour
{
    [SerializeField] private Transform _parentTransform;

    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        transform.localScale = _parentTransform.localScale;
    }

    public void EnableTrail()
    {
        _particleSystem.Play();
    }

    public void DisableTrail()
    {
        _particleSystem.Stop();
    }
}
