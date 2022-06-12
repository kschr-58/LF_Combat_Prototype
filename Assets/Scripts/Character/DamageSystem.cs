using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// DamageSystem is responsible for keeping track of an object's current damage, regeneration and kill state
public class DamageSystem : MonoBehaviour
{
    [SerializeField] private CharacterData _characterData;

    // Debugging
    [SerializeField] private Text _damageText;
    [SerializeField] private Text _damageRegenTimerText;
    [SerializeField] private Text _killStateText;

    private float _currentDamage;
    private float _regenTimer;
    private float _killStateTimer;
    private bool _inKillState;

    #region Unity Callback Methods

    private void Start()
    {
        _regenTimer = 0;
    }

    private void Update()
    {
        UpdateDebugText();

        if (_killStateTimer > 0)
        {
            DecreaseKillStateTimer();

            return;
        }

        // Activate kill state when current damage exceeds max damage treshold
        if (_currentDamage >= _characterData.MaxDamage)
        {
            _inKillState = true;

            _killStateTimer = _characterData.KillStateDuration;

            return;
        }

        _inKillState = false;

        if (_regenTimer > 0) DecreaseRegenTimer();
        else if (_regenTimer <= 0 && _currentDamage > 0) DecreaseDamage();
    }

    #endregion

    #region Public Methods

    public void DealDamage(float damage)
    {
        // Add damage and set timer to damage regen delay whenever object takes damage
        _currentDamage += damage;
        _regenTimer = _characterData.DamageRegenDelay;

        if (_killStateTimer > 0) _killStateTimer = _characterData.KillStateDuration;
    }

    #endregion

    #region Private Methods

    private void DecreaseRegenTimer()
    {
        _regenTimer -= Time.deltaTime;
    }

    private void DecreaseDamage()
    {
        // Set timer to 0 if it would otherwise be set to anything below 0
        if (_currentDamage - Time.deltaTime * _characterData.DamageRegenRate < 0)
        {
            _currentDamage = 0;
            return;
        }

        _currentDamage -= Time.deltaTime * _characterData.DamageRegenRate;
    }

    private void DecreaseKillStateTimer()
    {
        _killStateTimer -= Time.deltaTime;

        // Reset timers and lower damage
        if (_killStateTimer <= 0)
        {
            _inKillState = false;
            _currentDamage = _characterData.MaxDamage - _characterData.KillStateDamageRecovery;
            _regenTimer = 0;
        }
    }

    private void UpdateDebugText()
    {
        _damageRegenTimerText.text = $"Regen in: {Mathf.Round(_regenTimer)}";
        _damageText.text = $"Damage: {Mathf.Round(_currentDamage)} / {_characterData.MaxDamage}";
        _killStateText.text = _inKillState ? $"Kill state timer: {Mathf.Round(_killStateTimer)}" : "Not in kill state";
    }

    #endregion

    #region Getters & Setters

    public bool IsInKillstate()
    {
        return _inKillState;
    }

    #endregion
}
