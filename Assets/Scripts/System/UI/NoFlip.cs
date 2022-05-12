using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFlip : MonoBehaviour
{
    [SerializeField] private Transform _parentTransform;

    void Update()
    {
        transform.localScale = _parentTransform.localScale;
    }
}
