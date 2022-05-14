using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlickering : Prop
{
    [SerializeField] float timeTillFlicker;
    [SerializeField] float flickerIntensity;
    [SerializeField] int flickerCount;
    [SerializeField] float flickerInterval;

    Light2D _light;
    float _defaultIntensity;
    float _timer;
    Coroutine _flickerCoroutine;
    
    protected override void Start()
    {
        base.Start();

        _light = GetComponent<Light2D>();
        _defaultIntensity = _light.intensity;
        _timer = 0;
    }

    private void Update()
    {
        if (_flickerCoroutine != null) return;

        _timer += 1 * Time.deltaTime;

        if (_timer >= timeTillFlicker) 
        _flickerCoroutine = StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        for (int i = 0; i < flickerCount; i++)
        {
            _light.intensity = 0;

            yield return new WaitForSeconds(flickerInterval);

            _light.intensity = _defaultIntensity;

            yield return new WaitForSeconds(flickerInterval);

            _timer = 0;
            _flickerCoroutine = null;
        }
    }

    protected override void OnBigImpact()
    {
        if (_flickerCoroutine != null) StopCoroutine(_flickerCoroutine);
        _timer = 0;
        _flickerCoroutine = StartCoroutine(Flicker());
    }
}
