using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesCollection : MonoBehaviour
{
    public static ParticlesCollection Singleton { get; private set; }


    private void Awake()
    {
        if (Singleton != null) Destroy(this);
        else Singleton = this;
    }
}
