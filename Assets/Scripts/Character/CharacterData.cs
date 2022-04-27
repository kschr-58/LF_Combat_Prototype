using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterData : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] internal Rigidbody2D RB;
    [SerializeField] internal Animator Animator;
    [SerializeField] internal BoxCollider2D FeetCollider;
    [SerializeField] internal LayerMask TerrainLayerMask;
    [SerializeField] internal EffectLibrary EffectLibrary;
    [SerializeField] internal AnimationTransmitter AnimationTransmitter;
}
