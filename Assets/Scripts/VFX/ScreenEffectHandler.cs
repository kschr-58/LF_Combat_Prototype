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

    private Light2D[] _sceneLights;
    private GameObject[] _objectsToHide;
    private float _globalLightValue;

    private static ScreenEffectHandler singleton;

    #region Public Methods

    public static ScreenEffectHandler GetInstance()
    {
        return singleton;
    }

    public void MeleeHit()
    {
        StopAllCoroutines();
        StartCoroutine(SlowEffectCoroutine(_meleeTimeScale, _meleeSlowDuration));
    }

    public void Execution()
    {
        StopAllCoroutines();

        StartCoroutine(ExecutionCoroutine());
    }

    #endregion

    #region Unity Callback Methods

    private void Awake()
    {
        if (singleton != null) Destroy(this);

        else singleton = this;
    }

    private void Start()
    {
        _sceneLights = FindObjectsOfType<Light2D>();
        _objectsToHide = GameObject.FindGameObjectsWithTag("Effect_Invisible");

        foreach(Light2D light in _sceneLights)
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
