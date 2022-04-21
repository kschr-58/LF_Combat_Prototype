using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected GameObject m_uiPrefab;
    [SerializeField] protected Transform barrelPosition;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float damage;
    [SerializeField] protected float fireInterval;
    [SerializeField] protected int maxAmmo;

    protected WeaponUI m_weaponUI;
    protected int currentAmmo;
    protected ParticlesCollection particlesCollection;
    protected Crosshair crosshair;

    protected bool readyToFire;

    #region Private Methods

    private void Start()
    {
        this.particlesCollection = ParticlesCollection.GetInstance();
        this.crosshair = Crosshair.GetInstance();

        currentAmmo = maxAmmo;
        readyToFire = true;

        m_weaponUI = Instantiate(m_uiPrefab).GetComponent<WeaponUI>();

        m_weaponUI.transform.SetParent(UI.GetInstance().transform);
    }

    #endregion

    #region Abstract Methods

    public abstract void Fire();

    #endregion

    #region Getters & Setters

    public int GetMaxAmmo()
    {
        return maxAmmo;
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public virtual void SetCurrentAmmo(int newAmmoCount)
    {
        currentAmmo = newAmmoCount;
    }

    #endregion
}
