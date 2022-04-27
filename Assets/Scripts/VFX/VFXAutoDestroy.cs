using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXAutoDestroy : MonoBehaviour
{
    public void DestroyOnExit()
    {
        Destroy(gameObject);
    }
}
