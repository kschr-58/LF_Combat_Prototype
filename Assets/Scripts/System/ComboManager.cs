using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    // Serialized Fields
    [Header("Combo properties")]
    [Tooltip("Combo timer set to this number upon combo increase")]
    [SerializeField] private float _comboResetDelay = 3f;

    [Header("Combo UI")]
    [SerializeField] private ComboHUD _comboHUD;
    [SerializeField] private Text _comboText;
    [SerializeField] private Image _comboTimerImage;

    // Other Fields
    private int _currentComboCount;
    private float _comboResetTimer;

    // Singleton
    public static ComboManager s_instance {get; private set;}

    #region Unity Callback methods

    private void Awake()
    {
        // Singleton
        if (s_instance != null) Destroy(this);

        s_instance = this;
    }

    private void Start()
    {
        _currentComboCount = 0;
        _comboResetTimer = 0;

        _comboHUD.Hide();
    }

    private void Update()
    {
        // Actively decrease combo reset timer
        if (_comboResetTimer > 0) DecreaseComboTimer();
    }

    #endregion

    #region Public Methods

    public void OnComboHit(Transform target)
    {
        IncrementCombo();

        CameraController.Instance.OnComboHit(target);
    }

    public void EndCombo()
    {
        _comboHUD.Hide();

        _currentComboCount = 0;
        _comboResetTimer = 0;
        
        UpdateComboText();

        // Reset camera to default state
        CameraController.Instance.ResetCamera();
    }

    #endregion

    #region Private Methods

    private void IncrementCombo()
    {
        // Set combo text element active if currently inactive
        if (!_comboHUD.IsVisible) _comboHUD.Show();

        _currentComboCount++;
        _comboResetTimer = _comboResetDelay;

        UpdateComboText();
    }

    private void DecreaseComboTimer()
    {
        _comboResetTimer -= Time.deltaTime;

        // Decrease image fill amount based on timer
        _comboTimerImage.fillAmount = 1 - (1 - (_comboResetTimer / _comboResetDelay));

        if (_comboResetTimer <= 0) EndCombo();
    }

    private void UpdateComboText()
    {
        _comboText.text = $"{_currentComboCount} HITS";
    }

    #endregion

    #region Getters & Setters

    public int GetComboCount()
    {
        return _currentComboCount;
    }

    #endregion
}
