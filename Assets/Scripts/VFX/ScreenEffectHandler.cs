using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class ScreenEffectHandler : MonoBehaviour
{
    [SerializeField] float _meleeTimeScale;
    [SerializeField] float _meleeSlowDuration;
    [SerializeField] float _executionTimeScale;
    [SerializeField] float _executionEffectDuration;

    public static ScreenEffectHandler Instance { get; private set; }

    private Light2D[] _sceneLights;
    private GameObject[] _objectsToHide;
    private float _globalLightValue;

    public delegate void ImpactEventHandler();
    public event ImpactEventHandler OnBigImpact;

    #region Unity Callback Methods

    private void Awake()
    {
        if (Instance != null) Destroy(this);

        else Instance = this;
    }

    private void Start()
    {
        _sceneLights = FindObjectsOfType<Light2D>();
        _objectsToHide = GameObject.FindGameObjectsWithTag("Effect_Invisible");

        foreach (Light2D light in _sceneLights)
        {
            if (light.lightType == Light2D.LightType.Global)
            {
                _globalLightValue = light.intensity;

                break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Execution();
        }
    }

    #endregion

    #region Public Methods

    public void TriggerBigImpact()
    {
        OnBigImpact?.Invoke();
    }

    public void Execution()
    {
        StartCoroutine(ExecutionCoroutine());
    }

    public void InstantiateVFX(GameObject VFXPrefab, Vector2 position, Quaternion rotation)
    {
        GameObject newEffect = Instantiate(VFXPrefab, position, rotation, ParticlesCollection.Singleton.transform);
    }

    public void InstantiateVFX(GameObject VFXPrefab, Vector2 position, Quaternion rotation, Vector3 scale)
    {
        GameObject newEffect = Instantiate(VFXPrefab, position, rotation, ParticlesCollection.Singleton.transform);

        newEffect.transform.localScale = scale;
    }

    #endregion

    #region Coroutines

    private IEnumerator SlowEffectCoroutine(float newTimeScale, float duration)
    {
        Time.timeScale = newTimeScale;
        yield return new WaitForSeconds(duration * Time.timeScale);
        Time.timeScale = 1;
    }

    private IEnumerator ExecutionCoroutine()
    {
        StartCoroutine(SlowEffectCoroutine(_executionTimeScale, _executionEffectDuration));

        foreach (Light2D light in _sceneLights)
        {
            if (light.lightType == Light2D.LightType.Global)
            {
                light.intensity = 0f;
                continue;
            }
            else
            {
                light.enabled = false;
            }
        }

        foreach (GameObject objectToHide in _objectsToHide)
        {
            objectToHide.SetActive(false);
        }

        yield return new WaitForSeconds(_executionEffectDuration * Time.timeScale);

        foreach (Light2D light in _sceneLights)
        {
            if (light.lightType == Light2D.LightType.Global)
            {
                light.intensity = _globalLightValue;
                continue;
            }
            else
            {
                light.enabled = true;
            }
        }

        foreach (GameObject objectToHide in _objectsToHide)
        {
            objectToHide.SetActive(true);
        }
    }

    #endregion
}
