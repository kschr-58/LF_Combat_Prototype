using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Gun
{
    #region Public Methods

    public override void Fire()
    {
        if (!readyToFire) return;
        
        if (currentAmmo < 1) return;

        currentAmmo--;
        
        Vector3 vectorTarget = crosshair.transform.position - transform.position;

        float angle = Mathf.Atan2(vectorTarget.y, vectorTarget.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Instantiate(projectilePrefab, barrelPosition.transform.position, targetRotation, ParticlesCollection.Singleton.transform);

        m_weaponUI.Fire();

        StartCoroutine(FireInterval());
    }

    public override void SetCurrentAmmo(int newAmmoCount)
    {
        base.SetCurrentAmmo(newAmmoCount);

        m_weaponUI.LoadNextRound();
    }

    #endregion

    #region Coroutines

    private IEnumerator FireInterval()
    {
        this.readyToFire = false;
        yield return new WaitForSeconds(fireInterval);
        this.readyToFire = true;
    }

    #endregion
}
