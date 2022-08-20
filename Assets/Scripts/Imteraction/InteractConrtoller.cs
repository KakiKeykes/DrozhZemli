using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractConrtoller : MonoBehaviour
{
    public static event Action<IInteractable> OnAvailabilityInteractionItem;

    private static List<IInteractable> _interactableList = new List<IInteractable>();

    [SerializeField] private Transform _playerTransform;

    private void Update()
    {
        foreach(var interactable in _interactableList)
        {
            var isInInteractionDistance = (_playerTransform.position - interactable.InteractorGameObject.transform.position).sqrMagnitude <= interactable.InteractionDistance;
            if (isInInteractionDistance != interactable.CanInteract)
            {
                interactable.CanInteract = isInInteractionDistance;
                OnAvailabilityInteractionItem?.Invoke(interactable);
            }
        }
    }

    public static void RegistrateInteractable(IInteractable interactGameObject)
    {
        if (_interactableList.Contains(interactGameObject))
        {
            return;
        }
        _interactableList.Add(interactGameObject);
    }

    public static void DeregistrateInteractable(IInteractable interactGameObject)
    {
        if (_interactableList.Contains(interactGameObject))
        {
            _interactableList.Remove(interactGameObject);
        }
    }
}