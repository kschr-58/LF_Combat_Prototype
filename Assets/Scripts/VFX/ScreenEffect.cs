using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScreenEffect: MonoBehaviour
{
    [SerializeField] protected Color startingColor;
    [SerializeField] protected Color targetColor;

    protected Material originalMaterial;

    private void Start()
    {
        ScreenEffectHandler.GetInstance().OnColorChange += Effect;

        Initialize();
    }

    private void OnDestroy()
    {
        ScreenEffectHandler.GetInstance().OnColorChange -= Effect;
    }

    protected abstract void Initialize();

    protected abstract void Effect(Material material, float duration, float colorChangeModifier);
}
