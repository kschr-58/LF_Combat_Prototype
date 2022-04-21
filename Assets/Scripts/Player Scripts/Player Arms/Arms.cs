using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Gun m_gun;
    [SerializeField] float aimDuration;

    Animator m_animator;
    Crosshair m_crosshair;
    Coroutine fireCoroutine;

    int direction;
    bool isReloading;
    bool isPerfomingMelee;
    Dictionary<int, string> possibleDirections = new Dictionary<int, string>()
    {
        {90, "E"},
        {135, "NE"},
        {180, "N"},
        {-180, "N"},
        {225, "NW"},
        {270, "W"},
        {-90, "W"},
        {-45, "SW"},
        {-1, "S"},
        {0, "S"},
        {45, "SE"},
    };

    #region Public Methods

    public void FireWeapon()
    {
        // Cancel reload if reloading
        if (isReloading) CancelReload();

        if (IsPerformingAction()) return;

        if (fireCoroutine != null) StopCoroutine(fireCoroutine);
        fireCoroutine = StartCoroutine(FireCoroutine());
    }

    public void Melee()
    {
        if (IsPerformingAction()) return;

        m_animator.SetTrigger("Test Melee");

        isPerfomingMelee = true;
    }

    public void Reload()
    {
        // Cancel reload if already reloading
        if (isReloading) CancelReload();

        if (IsPerformingAction()) return;

        if (m_gun.GetCurrentAmmo() >= m_gun.GetMaxAmmo()) return;
        
        isReloading = true;
        m_animator.SetBool("Reloading", true);
    }

    // Called from animator
    public void InsertAmmo(int amount)
    {
        m_gun.SetCurrentAmmo(m_gun.GetCurrentAmmo() + amount);

        if (m_gun.GetCurrentAmmo() >= m_gun.GetMaxAmmo()) CancelReload();
    }

    public void CancelReload()
    {
        m_animator.SetBool("Reloading", false);
    }

    // Called from animator
    public void FinishReload()
    {
        isReloading = false;
    }

    public void FinishMelee()
    {
        isPerfomingMelee = false;
    }

    #endregion

    #region Private Methods

    private void Start()
    {
        m_animator = player.GetMyAnimator();
        m_crosshair = Crosshair.GetInstance();

        isReloading = false;
    }

    private int CalculateClosestDirection()
    {
        Vector3 vectorTarget = m_crosshair.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorTarget.y, vectorTarget.x) * Mathf.Rad2Deg + 90;

        float currentNearest = 180;
        int nearestDirection = direction;

        foreach (KeyValuePair<int, string> possibleDirection in possibleDirections)
        {
            int rotation = possibleDirection.Key;

            float rotationDifference = Mathf.Abs(angle - rotation);

            if (rotationDifference < currentNearest)
            {
                currentNearest = rotationDifference;

                nearestDirection = possibleDirection.Key;
            }
        }
        // Check if direction has updated
        if (direction != nearestDirection)
        {
            direction = nearestDirection;
        }

        return direction;
    }

    private bool IsPerformingAction()
    {
        return isReloading || isPerfomingMelee;
    }

    #endregion

    #region Coroutines

    public IEnumerator FireCoroutine()
    {
        int newDirection = CalculateClosestDirection();

        m_animator.SetInteger("Direction", newDirection);
        m_animator.SetBool("Aiming", true);

        yield return new WaitForEndOfFrame(); // Required for barrel position to update in animation

        m_gun.Fire();

        yield return new WaitForSeconds(aimDuration);
        m_animator.SetBool("Aiming", false);

        fireCoroutine = null;
    }

    #endregion
}
