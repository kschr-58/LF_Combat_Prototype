using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSensor : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    private LayerMask _interactionLayerMask;
    private Interactable _currentInteractable;

    #region Unity Callback Methods

    private void Start()
    {
        _interactionLayerMask = _playerData.InteractionLayerMask;
    }

    private void Update()
    {
        DetectInteractables();
    }

    #endregion

    #region Public Methods

    //

    #endregion

    #region Private Methods

    private void DetectInteractables()
    {
        // Circle cast in detection range radius to find possible interactables
        RaycastHit2D raycastHit = Physics2D.CircleCast(transform.position, _playerData.InteractionRadius, Vector2.right, 0f, _interactionLayerMask);

        if (!raycastHit)
        {
            if (_currentInteractable) 
            {
                // Hide visual indicator and remove current interactable once out of range
                _currentInteractable.DisplayIndicator(false);
                _currentInteractable = null;
            }
            
            return;
        }

        // Only the first interactable in range will be registered
        if (_currentInteractable) return;

        Interactable potentialInteractable = raycastHit.collider.GetComponent<Interactable>();

        // Failsafe to check if interactable component exists
        if (!potentialInteractable) return;

        _currentInteractable = potentialInteractable;

        // Display visual indicator on new interactable
        _currentInteractable.DisplayIndicator(true);
    }

    #endregion

    #region Getters & Setters

    public Interactable GetCurrentInteractable()
    {
        return _currentInteractable;
    }

    #endregion
}
