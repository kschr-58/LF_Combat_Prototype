using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCanvas : MonoBehaviour
{
    [SerializeField] Transform scaleTarget;

    Vector3 currentScale = new Vector3(1, 1, 1);

    void Update()
    {
        if (scaleTarget.localScale.x == -1) currentScale.x = -1;
        else currentScale.x = 1;

        transform.localScale = currentScale;
    }
}
