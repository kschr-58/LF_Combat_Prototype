using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainCamera : MonoBehaviour
{
    public static MainCamera Singleton { get; private set; }

    private CinemachineVirtualCamera _virtualCamera;
    private CinemachineBasicMultiChannelPerlin _perlin;
    private float _shakeTimer;

    #region Unity Callback Methods

    private void Awake()
    {
        if (Singleton) Destroy(gameObject);

        Singleton = this;
    }

    private void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _perlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        ReduceCameraShakeTimer();
    }

    #endregion

    #region Public Methods

    public void CameraShake(float intensity, float duration)
    {
        _perlin.m_AmplitudeGain = intensity;
        _shakeTimer = duration;
    }

    #endregion

    #region Private Methods

    private void ReduceCameraShakeTimer()
    {
        if (_shakeTimer > 0) _shakeTimer -= Time.deltaTime;

        if (_shakeTimer <= 0)
        {
            _perlin.m_AmplitudeGain = 0;
        }
    }

    #endregion
}
