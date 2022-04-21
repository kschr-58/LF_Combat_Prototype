using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteClone : MonoBehaviour
{
    [SerializeField] SpriteRenderer m_spriteRenderer;
    [SerializeField] SpriteRenderer targetSpriteRenderer;

    private void OnEnable()
    {
        Transform targetTransform = targetSpriteRenderer.transform;

        transform.position = targetTransform.position;
        transform.localScale = targetTransform.localScale;

        m_spriteRenderer.enabled = targetSpriteRenderer.gameObject.activeSelf;

        m_spriteRenderer.sprite = targetSpriteRenderer.sprite;
    }
}
