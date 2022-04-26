using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    // Serialized Fields
    [SerializeField] PlayerData player;

    // Component References
    private Rigidbody2D _rb;

    // Other References
    Vector2 nextVelocity;

    // Events
    public delegate void MeleeChange(bool isPerfomingMelee);
    public event MeleeChange OnMelee;

    #region Public Methods

    public void FinishMelee()
    {
        OnMelee(false);
    }

    #endregion
}
