using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] private Material _dissolveMaterial;
    private SpriteRenderer[] _spriteRenderers;

    private float _dissolveAmount = 0;
    private bool _isDissolving;
    private bool _isMaterializing;

    private void Start()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && !_isDissolving && !_isMaterializing)
        {
            if (_dissolveAmount <= 0) _isDissolving = true;
            else _isMaterializing = true;
        }

        if (_isDissolving)
        {
            foreach(SpriteRenderer sR in _spriteRenderers)
            {
                sR.material = new Material(_dissolveMaterial);
            }

            _dissolveAmount = Mathf.Clamp(_dissolveAmount + Time.deltaTime, 0, 2);

            foreach(SpriteRenderer sR in _spriteRenderers)
            {
                sR.material.SetFloat("_DissolveAmount", _dissolveAmount);
            }

            if (_dissolveAmount >= 2)
            {
                _isDissolving = false;
            }
        }

        if (_isMaterializing)
        {
            foreach(SpriteRenderer sR in _spriteRenderers)
            {
                sR.material = new Material(_dissolveMaterial);
            }

            _dissolveAmount = Mathf.Clamp01(_dissolveAmount - Time.deltaTime);

            foreach(SpriteRenderer sR in _spriteRenderers)
            {
                sR.material.SetFloat("_DissolveAmount", _dissolveAmount);
            }

            if (_dissolveAmount <= 0)
            {
                _isMaterializing = false;
            }
        }
    }
}
