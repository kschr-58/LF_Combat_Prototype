using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    static Crosshair singleton;

    Vector2 targetPosition;

    public static Crosshair GetInstance()
    {
        return singleton;
    }

    private void Awake()
    {
        if (singleton != null) Destroy(this);
        else singleton = this;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void Update()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = targetPosition;
    }
}
