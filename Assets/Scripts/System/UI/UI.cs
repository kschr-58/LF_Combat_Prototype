using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private static UI singleton;

    public static UI GetInstance()
    {
        return singleton;
    }

    private void Awake()
    {
        if (singleton != null) Destroy(this);
        singleton = this;
    }
}
