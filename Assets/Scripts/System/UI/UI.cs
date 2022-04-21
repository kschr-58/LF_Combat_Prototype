using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private static UI singleton;

    void Awake()
    {
        if (singleton != null) Destroy(this);
        singleton = this;
    }

    public static UI GetInstance()
    {
        return singleton;
    }
}
