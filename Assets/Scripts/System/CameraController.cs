using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    // Serialized Fields
    [Header("Components")]
    [SerializeField] private CinemachineVirtualCamera _defaultCamera;
    [SerializeField] private CinemachineVirtualCamera _comboCamera;
    [SerializeField] private Transform _followTarget;
    [SerializeField] private Transform _comboCenterPoint;

    [Header("Camera properties")]
    [SerializeField] float _minimalOrthographicSize = 5f;
    [SerializeField] float _comboZoom = 0.3f;

    [Header("Dutch effect properties")]
    [SerializeField] bool _useDutchEffect = false;
    [SerializeField] float _maxDutch = 3;

    // Components
    public static CameraController s_instance {get; private set;}
    private CinemachineBasicMultiChannelPerlin[] _cameraNoiseComponents;
    private CinemachineVirtualCamera _currentCamera;
    private Transform _comboTarget;
    private Coroutine _screenShakeCoroutine;

    // Other Fields
    private float _defaultOrthographicSize;

    #region Unity Callback Methods

    private void Awake()
    {
        // Singleton
        if (s_instance != null) Destroy(this);

        s_instance = this;
    }

    private void Start()
    {
        _currentCamera = _defaultCamera;
        // _defaultCamera.Follow = _followTarget;
        // _comboCamera.Follow = _followTarget;
        _defaultOrthographicSize = _comboCamera.m_Lens.OrthographicSize;

        _cameraNoiseComponents = new CinemachineBasicMultiChannelPerlin[2] 
            {_defaultCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(),
            _comboCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>()};
    }

    private void Update()
    {
        if (_comboTarget != null) PositionComboCenterPoint(_comboTarget);
    }

    #endregion

    #region Public Methods

    public void ShakeScreen(float duration)
    {
        foreach(CinemachineBasicMultiChannelPerlin noiseComponent in _cameraNoiseComponents)
        {
            noiseComponent.m_AmplitudeGain = 1;
            noiseComponent.m_FrequencyGain = 1;
        }

        if (_screenShakeCoroutine != null) StopCoroutine(_screenShakeCoroutine);

        _screenShakeCoroutine =  StartCoroutine(ScreenShakeCoroutine(duration));
    }

    public void ShakeScreen(float customAmplitude, float customFrequency, float duration)
    {
        foreach(CinemachineBasicMultiChannelPerlin noiseComponent in _cameraNoiseComponents)
        {
            noiseComponent.m_AmplitudeGain = customAmplitude;
            noiseComponent.m_FrequencyGain = customFrequency;
        }

        if (_screenShakeCoroutine != null) StopCoroutine(_screenShakeCoroutine);

        _screenShakeCoroutine =  StartCoroutine(ScreenShakeCoroutine(duration));
    }

    public void OnComboHit(Transform target)
    {
        _comboTarget = target;

        // Swap to combo camera if necessary
        if (_currentCamera != _comboCamera) SwapCamera();

        // Zoom towards target's transform
        Zoom();

        // Tilt camera if using dutch effect
        if (_useDutchEffect) TiltCamera();
    }

    public void ResetCamera()
    {
        // Reset combo target
        _comboTarget = null;

        // Swap back to default camera
        if (_currentCamera != _defaultCamera) SwapCamera();
    }

    #endregion

    #region Private Methods

    private void SwapCamera()
    {
        // Swap to combo camera if current camera is set to default camera
        if (_currentCamera == _defaultCamera)
        {
            _comboCamera.m_Lens.OrthographicSize = _defaultOrthographicSize;
            _comboCamera.m_Lens.Dutch = 0;

            _currentCamera = _comboCamera;

            _defaultCamera.Priority = 0;
            _comboCamera.Priority = 10;
        }
        // Swap to default camera if camera is set to combo camera
        else
        {
            _currentCamera = _defaultCamera;

            _defaultCamera.Priority = 10;
            _comboCamera.Priority = 0;
        }

    }

    private void Zoom()
    {
        float currentOrthographicSize = _currentCamera.m_Lens.OrthographicSize;

        // Check if current orthographic size does not fall below minimum size after shrinking
        if (currentOrthographicSize - _comboZoom <= _minimalOrthographicSize) return;

        // Shrink camera's orthographic size
        _currentCamera.m_Lens.OrthographicSize -= _comboZoom;
    }

    private void TiltCamera()
    {
        // Generate random dutch angle
        float newDutch = Random.Range(-_maxDutch, _maxDutch);

        _currentCamera.m_Lens.Dutch = newDutch;
    }

    // PositionComboCenterPoint method calculates center position between follow target and current combo target
    // This center point is used as LookAt point for the combo camera
    private void PositionComboCenterPoint(Transform comboTarget)
    {
        // Get world positions of follow target & combo target
        Vector3 followTargetWorldPos = transform.TransformPoint(_followTarget.position);
        Vector3 comboTargetWorldPos = transform.TransformPoint(comboTarget.position);

        // Calculate center position between targets
        Vector3 comboCenterPosition = followTargetWorldPos + (comboTargetWorldPos - followTargetWorldPos) / 2;

        comboCenterPosition.z = 0;

        // Position centerpoint object at center position
        _comboCenterPoint.position = comboCenterPosition;
    }

    #endregion

    #region Coroutines

    private IEnumerator ScreenShakeCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);

        //TODO gradually lower screenshake

        foreach(CinemachineBasicMultiChannelPerlin noiseComponent in _cameraNoiseComponents)
        {
            noiseComponent.m_AmplitudeGain = 0;
        }

        _screenShakeCoroutine = null;
    }

    #endregion
}
