using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CylinderHUD : WeaponUI
{
    [SerializeField] Animator myAnimator;
    [SerializeField] Image[] bullets;

    private int maxAmmoCount = 6;
    private int currentAmmoCount = 6;

    #region Public Methods

    public override void Fire()
    {
        // Retract 1 bullet from current ammo count
        currentAmmoCount--;

        // Make correct bullet image invisible
        bullets[maxAmmoCount - currentAmmoCount - 1].enabled = false;

        // Play turn animation
        myAnimator.SetTrigger("Turn");
    }

    public override void LoadNextRound()
    {
        myAnimator.SetTrigger("Turn Back");

        currentAmmoCount++;
        bullets[maxAmmoCount - currentAmmoCount].enabled = true;
    }

    public void CancelReload()
    {
        myAnimator.SetTrigger("Turn Back");
    }

    #endregion
}
