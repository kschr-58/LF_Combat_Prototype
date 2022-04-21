using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionClone : MonoBehaviour
{
    [SerializeField] Transform targetTransform;

    private void OnEnable()
    {
        transform.position = targetTransform.position;
    }
}
