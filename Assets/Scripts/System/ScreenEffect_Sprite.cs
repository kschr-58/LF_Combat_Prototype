using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffect_Sprite : ScreenEffect
{
    SpriteRenderer[] m_spriteRenderers;

    protected override void Initialize()
    {
        this.m_spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        this.originalMaterial = m_spriteRenderers[0].material;
    }

    protected override void Effect(Material material, float duration, float colorChangeModifier)
    {
        StopAllCoroutines();

        foreach(SpriteRenderer spriteRenderer in m_spriteRenderers)
        {
            StartCoroutine(ColorShift(material, spriteRenderer, duration, colorChangeModifier));
        }
    }

    private IEnumerator ColorShift(Material material, SpriteRenderer spriteRenderer, float duration, float colorChangeModifier)
    {
        Color originalColor = Color.white;

        spriteRenderer.material = material;
        spriteRenderer.color = startingColor;

        while(spriteRenderer.color != targetColor)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, colorChangeModifier);
            yield return null;
        }

        yield return new WaitForSeconds(duration * Time.timeScale);

        spriteRenderer.material = originalMaterial;

        while(spriteRenderer.color != originalColor)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, originalColor, colorChangeModifier);
            yield return null;
        }
    }
}
