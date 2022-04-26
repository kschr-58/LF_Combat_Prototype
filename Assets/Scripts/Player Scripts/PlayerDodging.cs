using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDodging : MonoBehaviour
{
    // Serialized Fields
    [SerializeField] PlayerData _player;
    [SerializeField] Text dodgeCountText; //TODO remove

    // Other References
    Vector2 _nextVelocity;
    Coroutine _dodgeCoroutine;
    Coroutine _dodgeRegenCoroutine;
    int _currentDodgeCount;

    // Events
    public delegate void DodgingChange(bool isDodging);
    public event DodgingChange OnDodge;

    bool isDodging;

    #region Public Methods

    public bool CanDodge()
    {
        return !isDodging && (_currentDodgeCount > 0);
    }

    public void RunningDodge()
    {
        if (_dodgeCoroutine != null) StopCoroutine(_dodgeCoroutine);

        _dodgeCoroutine = StartCoroutine(DodgeCoroutine(_player.RunningDodgeTime));
        StartCoroutine(RunningDodgeCoroutine());
    }

    public void StandingDodge()
    {
        if (_dodgeCoroutine != null) StopCoroutine(_dodgeCoroutine);;

        _dodgeCoroutine = StartCoroutine(DodgeCoroutine(_player.StandingDodgeTime));
        StartCoroutine(StandingDodgeCoroutine());
    }

    public void AerialDodge()
    {
        if (_dodgeCoroutine != null) StopCoroutine(_dodgeCoroutine);

        _dodgeCoroutine = StartCoroutine(DodgeCoroutine(_player.AerialDodgeTime));
        StartCoroutine(AerialDodgeCoroutine());
    }

    #endregion

    #region Private Methods

    private void Start()
    {
        _currentDodgeCount = _player.MaxDodgeCount;
    }

    private void Update()
    {
        HandleDodgeRegen();

        dodgeCountText.text = $"Dodge count: {_currentDodgeCount}";
    }

    private void HandleDodgeRegen()
    {
        if (_dodgeRegenCoroutine != null) return;

        if (_currentDodgeCount >= _player.MaxDodgeCount) return;

        _dodgeRegenCoroutine = StartCoroutine(RegenDodge());
    }
    
    #endregion

    #region Coroutines

    private IEnumerator RegenDodge()
    {
        yield return new WaitForSeconds(_player.DodgeRegenTime);

        if (_currentDodgeCount < _player.MaxDodgeCount) _currentDodgeCount++;

        _dodgeRegenCoroutine = null;
    }

    private IEnumerator DodgeCoroutine(float dodgeTime)
    {
        if (OnDodge != null) OnDodge(true);

        this._currentDodgeCount--;
        this.isDodging = true;

        _player.DodgeTrailComponent.ActivateTrail();

        yield return new WaitForSeconds(dodgeTime);

        if (OnDodge != null) OnDodge(false);
        else Debug.Log("No event listeners!");
        
        this.isDodging = false;

        _player.DodgeTrailComponent.DeactivateTrail();

        _dodgeCoroutine = null;
    }

    private IEnumerator RunningDodgeCoroutine()
    {
        float dodgeSpeed = _player.RunningDodgeSpeed * _player.transform.localScale.x;

        while (isDodging)
        {
            _nextVelocity.x = dodgeSpeed;
            _nextVelocity.y = 0f;

            _player.RB.velocity = _nextVelocity;
            yield return null;
        }
    }

    private IEnumerator StandingDodgeCoroutine()
    {
        float dodgeSpeed = _player.RunningDodgeSpeed * -0.1f * _player.transform.localScale.x;

        while (isDodging)
        {
            _nextVelocity.x = dodgeSpeed;
            _nextVelocity.y = 0f;

            _player.RB.velocity = _nextVelocity;
            yield return null;
        }
    }

    private IEnumerator AerialDodgeCoroutine()
    {
        float dodgeSpeed = _player.AerialDodgeSpeed * Mathf.Sign(_player.RB.velocity.x);
        float defaultGravity = _player.RB.gravityScale;

        _player.RB.gravityScale = 0f;

        while (isDodging)
        {
            _nextVelocity.x = dodgeSpeed;
            _nextVelocity.y = 0f;

            _player.RB.velocity = _nextVelocity;
            yield return null;
        }

        _player.RB.gravityScale = defaultGravity;
    }

    #endregion
}
