using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    private Coroutine _fireCoroutine;
    private int _direction;
    private bool _isReloading;
    private Dictionary<int, string> _possibleDirections = new Dictionary<int, string>()
    {
        {90, "E"},
        {135, "NE"},
        {180, "N"},
        {181, "N(L)"},
        {225, "NW"},
        {270, "W"},
        {-90, "W"},
        {-45, "SW"},
        {-1, "S(L)"},
        {0, "S"},
        {45, "SE"},
    };

    #region Public Methods

    public void FireWeapon()
    {
        // Cancel reload if reloading
        if (_isReloading) CancelReload();

        if (_isReloading) return;

        if (_fireCoroutine != null) StopCoroutine(_fireCoroutine);
        _fireCoroutine = StartCoroutine(FireCoroutine());
    }

    public void Reload() //TODO put into player state instead
    {
        // Cancel reload if already reloading
        if (_isReloading) CancelReload();

        if (_isReloading) return;

        if (_playerData.Gun.GetCurrentAmmo() >= _playerData.Gun.GetMaxAmmo()) return;
        
        _isReloading = true;
        _playerData.Animator.SetBool("Reloading", true);
    }

    // Called from animator
    public void InsertAmmo(int amount)
    {
        _playerData.Gun.SetCurrentAmmo(_playerData.Gun.GetCurrentAmmo() + amount);

        if (_playerData.Gun.GetCurrentAmmo() >= _playerData.Gun.GetMaxAmmo()) CancelReload();
    }

    public void CancelReload()
    {
        _playerData.Animator.SetBool("Reloading", false);
    }

    // Called from animator
    public void FinishReload()
    {
        _isReloading = false;
    }

    #endregion

    #region Private Methods

    private void Start()
    {
        _isReloading = false;
    }

    private int CalculateClosestDirection()
    {
        Vector3 vectorTarget = _playerData.Crosshair.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorTarget.y, vectorTarget.x) * Mathf.Rad2Deg + 90;

        float currentNearest = 180;
        int nearestDirection = _direction;

        foreach (KeyValuePair<int, string> possibleDirection in _possibleDirections)
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
        if (_direction != nearestDirection)
        {
            _direction = nearestDirection;
        }

        return _direction;
    }

    #endregion

    #region Coroutines

    public IEnumerator FireCoroutine()
    {
        int newDirection = CalculateClosestDirection();

        _playerData.Animator.SetBool("Aiming", true);
        _playerData.Animator.SetInteger("Direction", newDirection);

        // FIXME find better solution than frame skips to update barrel position
        yield return new WaitForEndOfFrame(); // Required for barrel position to update in animation

        _playerData.Gun.Fire();

        yield return new WaitForSeconds(_playerData.AimDuration);
        _playerData.Animator.SetBool("Aiming", false);

        _fireCoroutine = null;
    }

    #endregion
}
