using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private static Crosshair singleton;
    private Vector2 _targetPosition;

    public static Crosshair GetInstance()
    {
        return singleton;
    }

    private void Awake()
    {
        if (singleton != null) Destroy(this);
        else singleton = this;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void Update()
    {
        _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = _targetPosition;
    }
}
