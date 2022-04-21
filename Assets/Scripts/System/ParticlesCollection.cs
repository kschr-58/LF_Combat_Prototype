using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesCollection : MonoBehaviour
{
    static ParticlesCollection singleton;

    public static ParticlesCollection GetInstance()
    {
        return singleton;
    }

    private void Awake()
    {
        if (singleton != null) Destroy(this);
        else singleton = this;
    }
}
