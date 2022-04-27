using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffectHandler : MonoBehaviour
{
    [SerializeField] float _meleeTimeScaleModifier;
    [SerializeField] float _meleeSlowDuration;
    [SerializeField] Material _solidColorMaterial;
    [SerializeField] float _executionEffectDuration;
    [SerializeField] float _executionColorChangeModifier;
    [SerializeField] float _executionTimeScaleModifier;


    static ScreenEffectHandler singleton;

    public delegate void ColorEffect(Material material, float duration, float colorChangeModifier);
    public event ColorEffect OnColorChange;

    #region Public Methods

    public static ScreenEffectHandler GetInstance()
    {
        return singleton;
    }

    public void MeleeHit()
    {
        StopAllCoroutines();
        StartCoroutine(SlowEffectCoroutine(_meleeTimeScaleModifier, _meleeSlowDuration));
    }

    public void Execution()
    {
        OnColorChange(_solidColorMaterial, _executionEffectDuration, _executionColorChangeModifier);

        StopAllCoroutines();
        StartCoroutine(SlowEffectCoroutine(_executionTimeScaleModifier, _executionEffectDuration));
    }

    #endregion

    #region Private Methods

    private void Awake()
    {
        if (singleton != null) Destroy(this);

        else singleton = this;
    }

    private void Update()
    {
        if (OnColorChange == null) return;

        if (Input.GetKeyDown(KeyCode.M))
        {
            Execution();
        }
    }

    #endregion

    #region Coroutines

    private IEnumerator SlowEffectCoroutine(float modifier, float duration)
    {
        Time.timeScale = Time.timeScale * modifier;
        yield return new WaitForSeconds(duration * Time.timeScale);
        Time.timeScale = 1;
    }

    #endregion
}
