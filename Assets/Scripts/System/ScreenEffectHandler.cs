using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffectHandler : MonoBehaviour
{
    [SerializeField] Material solidColorMaterial;
    [SerializeField] float executionEffectDuration;
    [SerializeField] float executionColorChangeModifier;
    [SerializeField] float executionTimeScaleModifier;


    static ScreenEffectHandler singleton;

    public delegate void ColorEffect(Material material, float duration, float colorChangeModifier);
    public event ColorEffect OnColorChange;

    #region Public Methods

    public static ScreenEffectHandler GetInstance()
    {
        return singleton;
    }

    public void Execution()
    {
        OnColorChange(solidColorMaterial, executionEffectDuration, executionColorChangeModifier);

        StopAllCoroutines();
        StartCoroutine(EffectSlow(executionEffectDuration));
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

    private IEnumerator EffectSlow(float duration)
    {
        Time.timeScale = executionTimeScaleModifier;
        yield return new WaitForSeconds(duration * Time.timeScale);
        Time.timeScale = 1;
    }

    #endregion
}
