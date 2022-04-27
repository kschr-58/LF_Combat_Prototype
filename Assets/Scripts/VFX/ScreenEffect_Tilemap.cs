using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScreenEffect_Tilemap : ScreenEffect
{
    Tilemap m_tileMap;
    TilemapRenderer m_tileMapRenderer;
    
    protected override void Initialize()
    {
        this.m_tileMap = GetComponent<Tilemap>();
        this.m_tileMapRenderer = GetComponent<TilemapRenderer>();

        this.originalMaterial = m_tileMapRenderer.material;
    }

    protected override void Effect(Material material, float duration, float colorChangeModifier)
    {
        StopAllCoroutines();

        StartCoroutine(ColorShift(material, duration, colorChangeModifier));
    }

    private IEnumerator ColorShift(Material material, float duration, float colorChangeModifier)
    {
        Color originalColor = Color.white;

        m_tileMapRenderer.material = material;
        m_tileMap.color = startingColor;
        
        while(m_tileMap.color != targetColor)
        {
            m_tileMap.color = Color.Lerp(m_tileMap.color, targetColor, colorChangeModifier);
            yield return null;
        }

        yield return new WaitForSeconds(duration * Time.timeScale);

        m_tileMapRenderer.material = originalMaterial;

        while(m_tileMap.color != originalColor)
        {
            m_tileMap.color = Color.Lerp(m_tileMap.color, originalColor, colorChangeModifier);
            yield return null;
        }
    }
}
